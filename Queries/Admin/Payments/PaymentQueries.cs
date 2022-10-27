using Framework.Base;
using Framework.Helpers;

using System.Data.SqlClient;

namespace TCGplayerUI.Queries
{
    class PaymentQueries : StartBrowser
    {
        //drop the following temp table: SellerOrdersInBatch
        public void DropSellerOrdersInBatch()
        {
            string updateQuery = "if object_id('tempdb..#SellerOrdersInBatch') is NOT NULL drop table #SellerOrdersInBatch";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Create the SellerOrdersInBatch temp table.  Remove any seller orders that are eligible for payment, but shoud not be paid.
        public void CreateAndUpdateSellerOrdersInBatchTempTable(string currentDate, string sellerOrderId)
        {
            string updateQuery = "declare @PaymentScheduleId int = (select PaymentScheduleId from dbo.PaymentSchedule where PaymentDate = '" + currentDate + "')" + "\n" +
            "DECLARE" + "\n" +
            "@utcDate datetime = GETUTCDATE()," + "\n" +
            "@ScheduledPaymentDate date = '" + currentDate + "',\n" +

            "@MinSellerOrderId BIGINT" + "\n" +

            //Gets the MinSellerOrderId from the BookmarkId table.
            "SELECT @MinSellerOrderId = [BigIntId] FROM [dbo].[BookmarkId] WHERE [Name] = 'Prep Payment Batch Min SellerOrderId'" + "\n" +

            //Creates the temp table
            "CREATE TABLE #SellerOrdersInBatch([SellerOrderId] bigint, [SellerId] bigint, [HasRefund] bit, [HasPresale] bit, [EDD] datetime)" + "\n" +
            //Select what direct orders/products to pay
            "; WITH[AlreadyReimbursedProduct] AS (SELECT sop.[SellerOrderProductId], SUM(rosop.[Quantity]) AS[Quantity]" + "\n" +
            "FROM[TCGD].[ReimOrderSellerOrderProduct] rosop" + "\n" +
            "JOIN [dbo].[SellerOrderProduct] sop ON rosop.[SellerOrderProductId] = sop.[SellerOrderProductId]" + "\n" +
            "JOIN [TCGD].[ReimOrder] ro ON rosop.[ReimOrderId] = ro.[ReimOrderId]" + "\n" +
            "WHERE ro.[ReimOrderStatusId] >= 3" + "\n" +
            "AND(DATEADD(DAY, 1, ro.[ReceivedAt]) <= @utcDate OR ro.[ReceivedAt] is NULL)" + "\n" +
            "AND sop.[SellerOrderId] >= COALESCE(@MinSellerOrderId, 0)" + "\n" +
            "GROUP BY sop.[SellerOrderProductId])" + "\n" +
            //Select what direct orders/products to NOt to pay
            ", [UnreimbursedProduct] AS (SELECT DISTINCT so.[SellerOrderId]" + "\n" +
            "FROM[dbo].[SellerOrder] so" + "\n" +
            "JOIN [dbo].[SellerOrderProduct] sop ON so.[SellerOrderId] = sop.[SellerOrderId]" + "\n" +
            "LEFT JOIN [AlreadyReimbursedProduct] arp ON sop.[SellerOrderProductId] = arp.[SellerOrderProductId]" + "\n" +
            "WHERE so.[IsDirect] = 1" + "\n" +
            "AND sop.[Quantity] - ISNULL(arp.[Quantity], 0) > 0" + "\n" +
            "AND so.[SellerOrderStatusId] != 12" + "\n" +
            "AND so.[SellerOrderId] >= COALESCE(@MinSellerOrderId, 0))" + "\n" +

            "INSERT INTO #SellerOrdersInBatch ([SellerOrderId], [SellerId], [HasRefund], [HasPresale], [EDD])" + "\n" +
            "SELECT soib.[SellerOrderId], soib.[SellerId], 0 AS [HasRefund], 0 AS [HasPresale], soib.[FeedbackAvailableDate] AS [EDD]" + "\n" +
            "FROM (SELECT so.[SellerOrderId], so.[SellerId], so.[FeedbackAvailableDate], od.[ShippingCountry], so.[IsDirect]" + "\n" +
                ", ISNULL ([dbo].[GetEstimatedPaymentDate](so.[SellerId], so.[SellerOrderId], so.[FeedbackAvailableDate], so.[SellerOrderStatusId], s.[VPProcessing], s.[SellerTypeInd]" + "\n" +
                ", MAX(sof.[Question1]), MAX(t.[ValidatedDate]), MAX(r.ReceivedAt)), '12/31/5000') AS [EstimatedPaymentDate]" + "\n" +
                "FROM[dbo].[SellerOrder] so" + "\n" +
                "INNER JOIN [dbo].[Seller] s ON so.[SellerId] = s.[SellerId]" + "\n" +
                "INNER JOIN [dbo].[Order] o ON so.[OrderId] = o.[OrderId]" + "\n" +
                "INNER JOIN [dbo].[OrderDetail] od ON so.[OrderId] = od.[OrderId]" + "\n" +
                "LEFT JOIN [UnreimbursedProduct] up ON so.[SellerOrderId] = up.[SellerOrderId]" + "\n" +
                "LEFT JOIN [dbo].[SellerOrderFeedback] sof ON so.[SellerOrderId] = sof.[SellerOrderId]" + "\n" +
                    "AND sof.[DeletedAt] is NULL" + "\n" +
                    "AND (ISNULL(sof.[Question1], 0) = 4 OR ISNULL(sof.[Question1], 0) = 5)" + "\n" +
                "LEFT JOIN dbo.[TrackingNumber] t ON so.[SellerOrderId] = t.[SellerOrderid] and t.[ShippingStatusId] = 3" + "\n" +
                "INNER JOIN SellerOrderProduct sop ON sop.SellerOrderId = so.SellerOrderId" + "\n" +
                "LEFT JOIN TCGD.ReimOrderSellerOrderProduct rop ON rop.SellerOrderProductId = sop.SellerOrderProductId" + "\n" +
                "LEFT JOIN TCGD.ReimOrder r ON r.ReimOrderId = rop.ReimOrderId" + "\n" +

            "WHERE so.[SellerPayStatusId] not in (1, 5)" + "\n" +
            "AND so.[SellerOrderId] >= COALESCE(@MinSellerOrderId, 0)" + "\n" +
            //VPProcessing set to valid status
            "AND s.[VPProcessing] in ('BOFA', 'ACH', 'MASSPAY')" + "\n" +
            //VENDORRECEIVED, FULLREFUND, PARTIALREFUND
            "AND so.[SellerOrderStatusId] in (17, 12, 13)" + "\n" +
            "AND so.[SellerPaid] = 0" + "\n" +
            "AND(up.[SellerOrderId] is NULL OR s.IsForwardFreight = 1)" + "\n" +
            //Do not include seller orders from the TCGplayer seller associated with gift cards.
            "AND so.[SellerId] != 7" + "\n" +
            "AND NOT(so.ShippingMethodId IS NOT NULL" + "\n" +
            //Do not include POS orders
            "AND so.ShippingMethodId = 6)" + "\n" +
            "AND NOT(so.ShippingMethodId IS NOT NULL" + "\n" +
            "AND so.ShippingMethodId = 4" + "\n" +
            "AND o.PaymentTypeId IS NOT NULL" + "\n" +
            //Do not include ISPUPL orders
            "AND o.PaymentTypeId = 9)" + "\n" +

            "GROUP BY so.[SellerOrderId], so.[SellerId], so.[FeedbackAvailableDate], od.[ShippingCountry], so.[IsDirect], so.[SellerOrderStatusId], s.[VPProcessing], s.[SellerTypeInd]) soib" + "\n" +
            "WHERE soib.[EstimatedPaymentDate] <= @ScheduledPaymentDate" + "\n" +
            "OR(soib.[ShippingCountry] != 'US' AND soib.[IsDirect] = 1)" + "\n" +

            //Mark orders with refunds 
            "UPDATE soib SET soib.[HasRefund] = 1" + "\n" +
            "FROM #SellerOrdersInBatch soib" + "\n" +
            "INNER JOIN [dbo].[Refund] r ON soib.[SellerOrderId] = r.[SellerOrderId]" + "\n" +
            "INNER JOIN [dbo].[Seller] s ON soib.[SellerId] = s.[SellerId]" + "\n" +
            "WHERE r.[SellerOrderId] = soib.[SellerOrderId]" + "\n" +
            "AND((r.[RefundTypeId] in (1, 2) AND s.[SellerTypeInd] = 'Store')" + "\n" +
            "OR(r.[RefundTypeId] = 1 AND s.[SellerTypeInd] = 'Marketplace'))" + "\n" +

            //Mark orders with presales
            "UPDATE soib" + "\n" +
            "SET soib.[HasPresale] = 1" + "\n" +
            "FROM #SellerOrdersInBatch soib" + "\n" +
            "INNER JOIN [dbo].[SellerOrderProduct] sop ON soib.[SellerOrderId] = sop.[SellerOrderId]" + "\n" +
            "INNER JOIN [dbo].[StoreProductCondition] spc ON sop.[StoreProductConditionId] = spc.[StoreProductConditionID]" + "\n" +
            "INNER JOIN [PDT].[Product] p ON spc.[StoreProductId] = p.[ProductID]" + "\n" +
            "INNER JOIN [PDT].[ProductStatus] ps ON p.[ProductStatusId] = ps.[ProductStatusId]" + "\n" +
            "WHERE ps.[IsPreSale] = 1";
            
            var file = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string connectionString = file["connectionString"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = updateQuery;
                connection.Open();
                command.ExecuteNonQuery();

                //Update temp table
                string updateQuery2 = "declare @PaymentScheduleId int = (select PaymentScheduleId from dbo.PaymentSchedule where PaymentDate = '" + currentDate + "')," + "\n" +
                "@UpdatedByUserId bigint = (select top 1 UserId from dbo.[User] where ProviderEmailAddress = 'admin@auto.com')," + "\n" +
                "@utcDate datetime = GETUTCDATE()," + "\n" +
                "@ScheduledPaymentDate date = '" + currentDate + "'" + "\n" +

                "UPDATE so SET so.[SellerPayStatusId] = CASE WHEN soib.[HasPresale] = 1 THEN 9 ELSE 5 END, so.[SellerPayDate] = CASE[HasPresale] WHEN 1 THEN so.[SellerPayDate] ELSE dateadd(day, -2, @ScheduledPaymentDate) END," + "\n" +
                "so.[SellerPaid] = CASE[HasPresale] WHEN 1 THEN 0 ELSE 1 END, so.[UpdatedAt] = @utcDate, so.[UpdatedByUserId] = @UpdatedByUserId" + "\n" +
                "FROM #SellerOrdersInBatch soib" + "\n" +
                "INNER JOIN [dbo].[SellerOrder] so ON soib.[SellerOrderId] = so.[SellerOrderId]" + "\n" +
                "WHERE soib.SellerOrderId not in ('" + sellerOrderId + "')";

                command.CommandText = updateQuery2;
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        //Create the SellerOrdersInBatch temp table.  Remove any buylist offers that are eligible for payment, but shoud not be paid..
        public void CreateAndUpdateBuylistOfferInBatchTempTable(string currentDate, string buylistOfferId)
        {
            string updateQuery = "declare @PaymentScheduleId int = (select PaymentScheduleId from dbo.PaymentSchedule where PaymentDate = '" + currentDate + "')" + "\n" +
            "DECLARE" + "\n" +
            "@utcDate datetime = GETUTCDATE()," + "\n" +
            "@ScheduledPaymentDate date = '" + currentDate + "',\n" +

            "@MinSellerOrderId BIGINT" + "\n" +

            //Gets the MinSellerOrderId from the BookmarkId table.
            "SELECT @MinSellerOrderId = [BigIntId] FROM [dbo].[BookmarkId] WHERE [Name] = 'Prep Payment Batch Min SellerOrderId'" + "\n" +

            //Creates the temp table
            "CREATE TABLE #SellerOrdersInBatch([SellerOrderId] bigint, [SellerId] bigint, [HasRefund] bit, [HasPresale] bit, [EDD] datetime)" + "\n" +
            //Select what direct orders/products to pay
            "; WITH[AlreadyReimbursedProduct] AS (SELECT sop.[SellerOrderProductId], SUM(rosop.[Quantity]) AS[Quantity]" + "\n" +
            "FROM[TCGD].[ReimOrderSellerOrderProduct] rosop" + "\n" +
            "JOIN [dbo].[SellerOrderProduct] sop ON rosop.[SellerOrderProductId] = sop.[SellerOrderProductId]" + "\n" +
            "JOIN [TCGD].[ReimOrder] ro ON rosop.[ReimOrderId] = ro.[ReimOrderId]" + "\n" +
            "WHERE ro.[ReimOrderStatusId] >= 3" + "\n" +
            "AND(DATEADD(DAY, 1, ro.[ReceivedAt]) <= @utcDate OR ro.[ReceivedAt] is NULL)" + "\n" +
            "AND sop.[SellerOrderId] >= COALESCE(@MinSellerOrderId, 0)" + "\n" +
            "GROUP BY sop.[SellerOrderProductId])" + "\n" +
            //Select what direct orders/products to NOt to pay
            ", [UnreimbursedProduct] AS (SELECT DISTINCT so.[SellerOrderId]" + "\n" +
            "FROM[dbo].[SellerOrder] so" + "\n" +
            "JOIN [dbo].[SellerOrderProduct] sop ON so.[SellerOrderId] = sop.[SellerOrderId]" + "\n" +
            "LEFT JOIN [AlreadyReimbursedProduct] arp ON sop.[SellerOrderProductId] = arp.[SellerOrderProductId]" + "\n" +
            "WHERE so.[IsDirect] = 1" + "\n" +
            "AND sop.[Quantity] - ISNULL(arp.[Quantity], 0) > 0" + "\n" +
            "AND so.[SellerOrderStatusId] != 12" + "\n" +
            "AND so.[SellerOrderId] >= COALESCE(@MinSellerOrderId, 0))" + "\n" +

            "INSERT INTO #SellerOrdersInBatch ([SellerOrderId], [SellerId], [HasRefund], [HasPresale], [EDD])" + "\n" +
            "SELECT soib.[SellerOrderId], soib.[SellerId], 0 AS [HasRefund], 0 AS [HasPresale], soib.[FeedbackAvailableDate] AS [EDD]" + "\n" +
            "FROM (SELECT so.[SellerOrderId], so.[SellerId], so.[FeedbackAvailableDate], od.[ShippingCountry], so.[IsDirect]" + "\n" +
                ", ISNULL ([dbo].[GetEstimatedPaymentDate](so.[SellerId], so.[SellerOrderId], so.[FeedbackAvailableDate], so.[SellerOrderStatusId], s.[VPProcessing], s.[SellerTypeInd]" + "\n" +
                ", MAX(sof.[Question1]), MAX(t.[ValidatedDate]), MAX(r.ReceivedAt)), '12/31/5000') AS [EstimatedPaymentDate]" + "\n" +
                "FROM[dbo].[SellerOrder] so" + "\n" +
                "INNER JOIN [dbo].[Seller] s ON so.[SellerId] = s.[SellerId]" + "\n" +
                "INNER JOIN [dbo].[Order] o ON so.[OrderId] = o.[OrderId]" + "\n" +
                "INNER JOIN [dbo].[OrderDetail] od ON so.[OrderId] = od.[OrderId]" + "\n" +
                "LEFT JOIN [UnreimbursedProduct] up ON so.[SellerOrderId] = up.[SellerOrderId]" + "\n" +
                "LEFT JOIN [dbo].[SellerOrderFeedback] sof ON so.[SellerOrderId] = sof.[SellerOrderId]" + "\n" +
                    "AND sof.[DeletedAt] is NULL" + "\n" +
                    "AND (ISNULL(sof.[Question1], 0) = 4 OR ISNULL(sof.[Question1], 0) = 5)" + "\n" +
                "LEFT JOIN dbo.[TrackingNumber] t ON so.[SellerOrderId] = t.[SellerOrderid] and t.[ShippingStatusId] = 3" + "\n" +
                "INNER JOIN SellerOrderProduct sop ON sop.SellerOrderId = so.SellerOrderId" + "\n" +
                "LEFT JOIN TCGD.ReimOrderSellerOrderProduct rop ON rop.SellerOrderProductId = sop.SellerOrderProductId" + "\n" +
                "LEFT JOIN TCGD.ReimOrder r ON r.ReimOrderId = rop.ReimOrderId" + "\n" +

            "WHERE so.[SellerPayStatusId] not in (1, 5)" + "\n" +
            "AND so.[SellerOrderId] >= COALESCE(@MinSellerOrderId, 0)" + "\n" +
            //VPProcessing set to valid status
            "AND s.[VPProcessing] in ('BOFA', 'ACH', 'MASSPAY')" + "\n" +
            //VENDORRECEIVED, FULLREFUND, PARTIALREFUND
            "AND so.[SellerOrderStatusId] in (17, 12, 13)" + "\n" +
            "AND so.[SellerPaid] = 0" + "\n" +
            "AND(up.[SellerOrderId] is NULL OR s.IsForwardFreight = 1)" + "\n" +
            //Do not include seller orders from the TCGplayer seller associated with gift cards.
            "AND so.[SellerId] != 7" + "\n" +
            "AND NOT(so.ShippingMethodId IS NOT NULL" + "\n" +
            //Do not include POS orders
            "AND so.ShippingMethodId = 6)" + "\n" +
            "AND NOT(so.ShippingMethodId IS NOT NULL" + "\n" +
            "AND so.ShippingMethodId = 4" + "\n" +
            "AND o.PaymentTypeId IS NOT NULL" + "\n" +
            //Do not include ISPUPL orders
            "AND o.PaymentTypeId = 9)" + "\n" +

            "GROUP BY so.[SellerOrderId], so.[SellerId], so.[FeedbackAvailableDate], od.[ShippingCountry], so.[IsDirect], so.[SellerOrderStatusId], s.[VPProcessing], s.[SellerTypeInd]) soib" + "\n" +
            "WHERE soib.[EstimatedPaymentDate] <= @ScheduledPaymentDate" + "\n" +
            "OR(soib.[ShippingCountry] != 'US' AND soib.[IsDirect] = 1)" + "\n" +

            //Mark orders with refunds 
            "UPDATE soib SET soib.[HasRefund] = 1" + "\n" +
            "FROM #SellerOrdersInBatch soib" + "\n" +
            "INNER JOIN [dbo].[Refund] r ON soib.[SellerOrderId] = r.[SellerOrderId]" + "\n" +
            "INNER JOIN [dbo].[Seller] s ON soib.[SellerId] = s.[SellerId]" + "\n" +
            "WHERE r.[SellerOrderId] = soib.[SellerOrderId]" + "\n" +
            "AND((r.[RefundTypeId] in (1, 2) AND s.[SellerTypeInd] = 'Store')" + "\n" +
            "OR(r.[RefundTypeId] = 1 AND s.[SellerTypeInd] = 'Marketplace'))" + "\n" +

            //Mark orders with presales
            "UPDATE soib" + "\n" +
            "SET soib.[HasPresale] = 1" + "\n" +
            "FROM #SellerOrdersInBatch soib" + "\n" +
            "INNER JOIN [dbo].[SellerOrderProduct] sop ON soib.[SellerOrderId] = sop.[SellerOrderId]" + "\n" +
            "INNER JOIN [dbo].[StoreProductCondition] spc ON sop.[StoreProductConditionId] = spc.[StoreProductConditionID]" + "\n" +
            "INNER JOIN [PDT].[Product] p ON spc.[StoreProductId] = p.[ProductID]" + "\n" +
            "INNER JOIN [PDT].[ProductStatus] ps ON p.[ProductStatusId] = ps.[ProductStatusId]" + "\n" +
            "WHERE ps.[IsPreSale] = 1";

            var file = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string connectionString = file["connectionString"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = updateQuery;
                connection.Open();
                command.ExecuteNonQuery();

                //Update temp table
                string updateQuery2 = "declare @PaymentScheduleId int = (select PaymentScheduleId from dbo.PaymentSchedule where PaymentDate = '" + currentDate + "')," + "\n" +
                "@UpdatedByUserId bigint = (select top 1 UserId from dbo.[User] where ProviderEmailAddress = 'admin@auto.com')," + "\n" +
                "@utcDate datetime = GETUTCDATE()," + "\n" +
                "@ScheduledPaymentDate date = '" + currentDate + "'" + "\n" +

                "UPDATE bo SET bo.[TotalPayment] = ISNULL(bo.[FinalProductCost], 0) - ISNULL(bo.[ReturnShipping], 0) , bo.PaidAt = dateadd(day, -2, @utcDate)" + "\n" +
                ", bo.[UpdatedAt] = @utcDate, bo.[UpdatedByUserId] = @UpdatedByUserId" + "\n" +
                "FROM[BYL].[BuylistOffer] bo" + "\n" +
                "WHERE bo.[BuyListOfferStatusId] >= 9" + "\n" +
                "AND bo.[BuylistTransactionTypeId] = 1" + "\n" +
                "AND bo.[TotalPayment] is NULL" + "\n" +
                "AND bo.[PaidAt] is NULL" + "\n" +
                "AND bo.BuyListOfferId not in ('" + buylistOfferId + "')";

                command.CommandText = updateQuery2;
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        //Get the PaymentBatchId from the dbo.PaymentBatch table where the PaymentBatchStatus is MAKEPAYMENT 
        public string[] GetPaymentBatchIdInMakePaymentStatus()
        {
            string sql = "SELECT PaymentBatchId FROM dbo.PaymentBatch where PaymentBatchStatusId = 4";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
        }

        //Get the PaymentBatchIds from the dbo.PaymentBatch table where the ProcessedDate falls within today's date. 
        public string[] GetPaymentBatchIdWithinSpecificDateRangeArray(string date)
        {
            string sql = "select PaymentBatchId from paymentbatch where ProcessedDate BETWEEN '" + date + " 00:00:00.000' AND '" + date + " 23:59:59.000'";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
        }
                
        //Get the PaymentScheduleId from the dbo.PaymentSchedule table using a specific PaymentDate.
        public string PaymentScheduleId(string paymentDate)
        {
            string sql = "select PaymentScheduleId from dbo.PaymentSchedule where PaymentDate = '" + paymentDate + "'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get all the PaymentScheduleIds from the dbo.PaymentSchedule table where PaymentDate is prior to today and IsPaid = 0.
        public string[] PaymentScheduleIdNotPaid(string paymentDate)
        {
            string sql = "select PaymentScheduleId from dbo.PaymentSchedule where IsPaid = 0 and PaymentDate < '" + paymentDate + "'";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
        }


        //Update IsPaid = 0 in the dbo.PaymentSchedule table for a specific paymentScheduleId  
        public void UpdatePaymentSchedule(string adminProviderName, string paymentScheduleId)
        {
            //string updateQuery = "Update dbo.PaymentSchedule set IsPaid = 0 where PaymentScheduleId = " + paymentScheduleId;
            string updateQuery = "Update dbo.PaymentSchedule set IsPaid = 0, UpdatedByUserId = (select top 1 UserId from dbo.[User] where ProviderEmailAddress = '" + adminProviderName + "')  where PaymentScheduleId = " + paymentScheduleId;

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Add a payment schedule to the dbo.PaymentSchedule table 
        public void AddPaymentSchedule(string paymentDate, string etaDate, string adminProviderName)
        {
            string updateQuery = "Insert into dbo.PaymentSchedule (PaymentDate, IsPaid, EtaDate, UpdatedByUserId)" + "\n" +
            "values('" + paymentDate + "', 0, '" + etaDate + "', (select top 1 UserId from dbo.[User] where ProviderEmailAddress = '" + adminProviderName + "'))";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Run this query to reset the Pay MP Sellers job (ACH Payment).  This will allow the job to be run more than once a day.
        public void ResetPayMPSellersJob()
        {
            string sql = "DECLARE @JobHistoryId int" + "\n" +
            "DECLARE @JobDefinitionId int = (Select Top 1 JobDefinitionId from MON.JobDefinition" + "\n" +
            "Where Jobname = 'ACH Payment')" + "\n" +
            "Set @JobHistoryId = (Select Top 1 JobExecutionHistoryId From MON.JobExecutionHistory" + "\n" +
            "Where JobDefinitionId = @JobDefinitionId" + "\n" +
            "Order By StartedAt Desc)" + "\n" +
            "Update MON.JobExecutionHistory" + "\n" +
            "Set WasSuccessful = 0" + "\n" +
            "Where JobExecutionHistoryId = @JobHistoryId";

            DBSingleResultHelpers.DB_Method(sql);
        }

        //Run this query to reset the Buylist Player Payment job (ACH Payment).  This will allow the job to be run more than once a day.
        public void ResetBuylistPlayerPaymentJob()
        {
            string sql = "DECLARE @JobHistoryId int" + "\n" +
            "DECLARE @JobDefinitionId int = (Select Top 1 JobDefinitionId from MON.JobDefinition" + "\n" +
            "Where Jobname = 'Buylist Player payment')" + "\n" +
            "Set @JobHistoryId = (Select Top 1 JobExecutionHistoryId From MON.JobExecutionHistory" + "\n" +
            "Where JobDefinitionId = @JobDefinitionId" + "\n" +
            "Order By StartedAt Desc)" + "\n" +
            "Update MON.JobExecutionHistory" + "\n" +
            "Set WasSuccessful = 0" + "\n" +
            "Where JobExecutionHistoryId = @JobHistoryId";

            DBSingleResultHelpers.DB_Method(sql);
        }

        //Add a tracking number to the dbo.TrackingNumber table 
        public void AddTrackingNumber(string orderNumber, string currentDate)
        {
            string updateQuery = "Insert into dbo.TrackingNumber (CarrierId, AutoCarrierId, SellerOrderid, EmailId, ShippingStatusId, [Value], ValidatedDate, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, CarrierStatus, TrackingSvcStatusId, IsHidden, EasyPostInfoId)" + "\n" +
            "values (1, 1, (SELECT SellerOrderId FROM dbo.sellerOrder WHERE OrderNumber = '" + orderNumber + "'), NULL, 10, 9101148008600482643942, NULL, '" + currentDate + " 00:00:00.000', '" + currentDate + " 00:00:00.000', -1000, NULL, NULL, 0, 0, NULL)";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update FeedbackAvailableDate in the dbo.Sellerorder table
        public void UpdateFeedbackAvailableDate(string feedbackDate, string orderNumber)
        {
            string updateQuery = "update sellerorder set FeedbackAvailableDate = '" + feedbackDate + " 00:00:00.000' where SellerOrderId in (select SellerOrderId from sellerorder where OrderNumber = '" + orderNumber + "')";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update VPProcessing = 'ACH' in the dbo.Seller table
        public void UpdateVPProcessingToACH(string sellerId)
        {
            string updateQuery = "update dbo.seller set VPProcessing = 'ACH' where SellerId = '" + sellerId + "'";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update IsW9Required = 0 in the dbo.Seller table
        public void UpdateIsW9Required0(string sellerId)
        {
            string updateQuery = "update dbo.seller set IsW9Required = 0 where SellerId = '" + sellerId + "'";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }
}
