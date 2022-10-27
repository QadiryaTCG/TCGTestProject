using Framework.Base;
using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries
{
    class DirectRIQueries : StartBrowser
    {

        // Confirm a Direct order is placed, and Seller Order Status is Vendor Received (SellerOrderStatusId=17)
        public bool ConfirmDirectOrder(string directOrderNumber)
        {
            string sql = "SELECT so.SellerOrderStatusId " + "\n" +
                         "FROM dbo.SellerOrder so" + "\n" +
                         "Inner Join dbo.[Order] o ON so.OrderId = o.OrderId" + "\n" +
                         "Inner Join TCGD.DirectOrder do ON so.OrderId = do.OrderId" + "\n" +
                         "WHERE do.DirectOrderNumber = '" + directOrderNumber + "' ";
            string value = DBSingleResultHelpers.DB_Method(sql);
            if (value.Equals("17"))
            { return true; }
            else
            { return false; }
            Console.WriteLine("Database connection is done!");
        }

       

        public void ResetRI(string sellerOrderNumber)
        {
            string updateQuery = "UPDATE dbo.SellerOrder" + "\n" +
                                 "SET CreatedAt = Getdate() - 15" + "\n" +
                                 "WHERE OrderNumber in ('"+ sellerOrderNumber + "')";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Database connection is done!");
        }


        public string GetAutoRINumber(string sellerId)
        {
            string sql = "SELECT TOP 1 ReimOrderNumber" + "\n" +
                         "FROM TCGD.ReimOrder" + "\n" +
                         "WHERE SellerId = '" + sellerId + "' and ReimOrderNumber like '%auto' and CAST(CreatedAt AS DATE) = Cast(GetUTCDate() AS DATE)";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
            Console.WriteLine("Database connection is done!");
        }

        public void ConfirmReimOrderSchedule()
        {
            string updateQuery = "BEGIN" + "\n" +
                         "UPDATE TCGD.ReimOrderSchedule" + "\n" +
                         "SET IsGenerated = 0" + "\n" +
                         "WHERE[Date] = CAST(GETUTCDATE() AS DATE)" + "\n" +
                         "IF NOT EXISTS(SELECT 1 FROM TCGD.ReimOrderSchedule WHERE DATE = CAST(GETUTCDATE() AS DATE))" + "\n" +
                         "BEGIN" + "\n" +
                         "INSERT INTO TCGD.ReimOrderSchedule([Date], ReceivedBy, IsGenerated)" + "\n" +
                         "VALUES(CAST(GETUTCDATE() AS DATE), DATEADD(DAY, 5, CAST(GETUTCDATE() AS DATE)), 0)" + "\n" +
                         "END" + "\n" +
                         "END";
            
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Database connection is done!");
        }


        //public void ConfirmReimOrderSchedule()
        //{
        //    string updateQuery = "IF EXISTS(SELECT 1 FROM [TCGD].[ReimOrderSchedule] WHERE Date = GetDate())" + "\n" +
        //                 "BEGIN" + "\n" +
        //                 "UPDATE [TCGD].[ReimOrderSchedule] SET IsGenerated = 0  WHERE Date = GetDate()" + "\n" +
        //                 "End" + "\n" +
        //                 "Else Begin" + "\n" +
        //                 "INSERT INTO TCGD.ReimOrderSchedule ([Date], ReceivedBy, IsGenerated)" + "\n" +
        //                 "VALUES (Getdate(), Getdate() + 3, 0)" + "\n" +
        //                 "End";
        //    DBUpdateHelpers.DBUpdateMethod(updateQuery);
        //    Console.WriteLine("Database connection is done!");
        //}

        public string[] GetAutoRIMTGRaresProducts()
        {
            string sql = "SELECT TOP 100" + "\n" +
                         "b.SellerId" + "\n" +
                         ", p.ProductName" + "\n" +
                         ", sn.SetName" + "\n" +
                         ", c.ConditionName" + "\n" +
                         ", b.Quantity AS [SellersBuylistQuantity]" + "\n" +
                         ", s.Quantity AS [SellersMarketplaceQuantity]" + "\n" +
                         ", d.QtyAvailable AS [DirectQuantityAvailable]" + "\n" +
                         "FROM BYL.BuylistPurchaseShelvedInventory b" + "\n" +
                         "LEFT JOIN dbo.StorePrice s ON s.StoreProductConditionId = b.ProductConditionId AND b.SellerId = s.SellerId" + "\n" +
                         "LEFT JOIN TCGD.DirectInventory d ON d.ProductConditionID = b.ProductConditionId" + "\n" +
                         "join pdt.productcondition pc on pc.ProductConditionId = b.ProductConditionId" + "\n" +
                         "join pdt.Product p on p.ProductId = pc.ProductId" + "\n" +
                         "join pdt.Condition c on c.ConditionId = pc.ConditionId" + "\n" +
                         "join PDT.SetName sn on sn.SetNameId = p.setnameid" + "\n" +
                         "where b.Quantity > 0 and s.Quantity > 0 and d.QtyAvailable > 0 and b.SellerId = 249" + "\n" +
                         "ORDER BY p.ProductName ASC";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
            Console.WriteLine("Database connection is done!");
        }

        public string GetReimOrderNumberMTG()
        {
            string sql = "SELECT top 1 ReimOrderNumber" + "\n" +
                         "FROM TCGD.ReimOrder" + "\n" +
                         "WHERE TCGD.ReimOrder.Sellerid='249'" + "\n" +
                         "ORDER BY ReimOrderId DESC";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Update ReceivedAt 2 days in the past in the TCGD.ReimOrder table
        public void UpdateReceivedAt(string ReimOrderNumber)
        {
            string updateQuery = "update tcgd.ReimOrder set ReceivedAt = dateadd(day, -2, getutcdate()) where ReimOrderNumber = '" + ReimOrderNumber + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update ShelvedAt 1 day in the past in the TCGD.ReimOrder table
        public void UpdateShelvedAt(string ReimOrderNumber)
        {
            string updateQuery = "update tcgd.ReimOrder set ShelvedAt = dateadd(day, -1, getutcdate()) where ReimOrderNumber = '" + ReimOrderNumber + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }
}
