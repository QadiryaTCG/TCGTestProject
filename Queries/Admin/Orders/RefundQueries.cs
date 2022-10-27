using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    public class RefundQueries : StartBrowser
    {

        //Start of SellerOrder Table
        //SellerOrder Table: SellerOrderStatusId for a refunded order
        public string SellerOrderStatusId(string orderNumber)
        {
            string sql = "Select top 1 so.SellerOrderStatusId from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
            "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrderStatusId = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderStatusId;
        }

        //SellerOrder Table: SellerOrderShippingAmt for a refunded order
        public string SellerOrderShippingAmt(string orderNumber)
        {
            string sql = "Select so.ShippingAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrdershippingAmt = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrdershippingAmt;
        }

        //SellerOrder Table: EffectiveTaxRate for a refunded order
        public string SellerOrderEffectiveTaxRate(string orderNumber)
        {
            string sql = "Select so.EffectiveTaxRate from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrderEffectiveTaxRate = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderEffectiveTaxRate;
        }

        //SellerOrder Table: OrderAmt for a refunded order
        public string SellerOrderOrderAmt(string orderNumber)
        {
            string sql = "Select so.OrderAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string SellerOrderOrderAmt = DBSingleResultHelpers.DB_Method(sql);
            return SellerOrderOrderAmt;
        }

        //SellerOrder Table: ProductAmt for a refunded order
        public string SellerOrderProductAmt(string orderNumber)
        {
            string sql = "Select so.ProductAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrderProductAmt = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderProductAmt;
        }

        //SellerOrder Table: CurrentAmt for a refunded order
        public string SellerOrderCurrentAmt(string orderNumber)
        {
            string sql = "Select so.CurrentAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrderCurrentAmt = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderCurrentAmt;
        }

        //SellerOrder Table: RefundAmt for a refunded order
        public string SellerOrderRefundAmt(string orderNumber)
        {
            string sql = "Select so.RefundAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrderRefundAmt = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderRefundAmt;
        }

        //SellerOrder Table: CommissionFeesAdded for a refunded order
        public string SellerOrderCommissionFeesAdded(string orderNumber)
        {
            string sql = "Select so.CommissionFeesAdded from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrderCommissionFeesAdded = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderCommissionFeesAdded;
        }

        //SellerOrder Table: SellerOrderTransactionFeesAdded for a refunded order
        public string SellerOrderTransactionFeesAdded(string orderNumber)
        {
            string sql = "Select so.TransactionFeesAdded from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrderTransactionFeesAdded = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderTransactionFeesAdded;
        }

        //SellerOrder Table: IsTCGTax for a refunded order
        public string SellerOrderIsTCGTax(string orderNumber)
        {
            string sql = "Select so.IsTCGTax from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string sellerOrderIsTCGTax = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderIsTCGTax;
        }
        //End of SellerOrder Table




        //Start of Order Table
        //Order Table: SellerOrderShippingAmt for a refunded order        
        public string OrderStatusId(string orderNumber)
        {
            //string sql = "Select o.OrderStatusId from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
            // "Where so.OrderNumber = '" + orderNumber + "'";
            string sql = "Select OrderStatusId from dbo.[Order] where OrderId in (select OrderId from SellerOrder where OrderNumber = '" + orderNumber + "')";
            string orderStatusId = DBSingleResultHelpers.DB_Method(sql);
            return orderStatusId;
        }

        //Order Table:  for a refunded order
        public string OrderTotalShippingAmt(string orderNumber)
        {
            string sql = "Select o.TotalShippingAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string orderTotalShippingAmt = DBSingleResultHelpers.DB_Method(sql);
            return orderTotalShippingAmt;
        }

        //Order Table:  for a refunded order
        public string OrderTotalSellerTaxAmt(string orderNumber)
        {
            string sql = "Select o.TotalSellerTaxAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string orderTotalSellerTaxAmt = DBSingleResultHelpers.DB_Method(sql);
            return orderTotalSellerTaxAmt;
        }

        //Order Table:  for a refunded order
        public string OrderTCGTaxAmt(string orderNumber)
        {
            string sql = "Select o.TCGTaxAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string orderTCGTaxAmt = DBSingleResultHelpers.DB_Method(sql);
            return orderTCGTaxAmt;
        }

        //Order Table:  for a refunded order
        public string OrderCurrentAmt(string orderNumber)
        {
            string sql = "Select o.CurrentAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string orderCurrentAmt = DBSingleResultHelpers.DB_Method(sql);
            return orderCurrentAmt;
        }
        //End of Order Table



        //Start of Refund Table
        //Refund Table: RefundTypeId
        public string RefundTypeId(string orderNumber)
        {
            string sql = "Select top 1 r.RefundTypeId from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string refundTypeId = DBSingleResultHelpers.DB_Method(sql);
            return refundTypeId;
        }

        //Refund Table: RefundStatusId
        public string RefundStatusId(string orderNumber)
        {
            string sql = "Select top 1 r.RefundStatusId from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string refundStatusId = DBSingleResultHelpers.DB_Method(sql);
            return refundStatusId;
        }

        //SellerOrder Table Table: RefundAmt
        public string RefundTotalAmt(string orderNumber)
        {
            string sql = "Select top 1 CONVERT(varchar, r.TotalAmt) AS Price from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string refundTotalAmt = DBSingleResultHelpers.DB_Method(sql);
            return refundTotalAmt;
        }

        //Get refunded tax from refund table using an OrderNumber.  Query orders by RefundId desc so will get latest refund
        public string RefundedTaxAmt(string orderNumber)
        {
            string taxAmount = "0.00";
            //Refund Table: NYSalesTaxAmt for an order
            string sql = "Select top 1 r.NYSalesTaxAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string NYSalesTaxAmt = DBSingleResultHelpers.DB_Method(sql);
            //Refund Table: VendorSalesTaxAmt for an order
            sql = "Select top 1 r.VendorSalesTaxAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string VendorSalesTaxAmt = DBSingleResultHelpers.DB_Method(sql);
            if (NYSalesTaxAmt != "0.00")
            {
                taxAmount = NYSalesTaxAmt;
            }
            else if (VendorSalesTaxAmt != "0.00")
            {
                taxAmount = VendorSalesTaxAmt;
            }
            return taxAmount;
        }


        //Refund Table: RefundRequestedAmt
        public string RefundRequestedAmt(string orderNumber)
        {
            string sql = "Select top 1 r.RequestedAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string refundRequestedAmt = DBSingleResultHelpers.DB_Method(sql);
            return refundRequestedAmt;
        }

        //Refund Table: ShippingAmt
        public string RefundShippingAmt(string orderNumber)
        {
            string sql = "Select top 1 r.ShippingAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string refundShippingAmt = DBSingleResultHelpers.DB_Method(sql);
            return refundShippingAmt;
        }

        //Refund Table: ShippingAmt for direct orders.  Based on OrderId not OrderNumber
        public string RefundShippingAmtDirectOrder(string orderNumber)
        {
            string sql = "Select ShippingAmt from dbo.Refund  Where OrderId in (select orderId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string refundShippingAmt = DBSingleResultHelpers.DB_Method(sql);
            return refundShippingAmt;
        }

        //Refund Table: IsCredit
        public string RefundIsCredit(string orderNumber)
        {
            string sql = "Select r.IsCredit from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string refundIsCredit = DBSingleResultHelpers.DB_Method(sql);
            return refundIsCredit;
        }

        //Refund Table: RefundNote
        public string RefundNote(string orderNumber)
        {
            string sql = "Select top 1 r.RefundNote from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string refundNote = DBSingleResultHelpers.DB_Method(sql);
            return refundNote;
        }

        //Refund Table: IsTransactionProcessed
        public string RefundIsTransactionProcessed(string orderNumber)
        {
            string sql = "Select top 1 r.IsTransactionProcessed from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string refundIsTransactionProcessed = DBSingleResultHelpers.DB_Method(sql);
            return refundIsTransactionProcessed;
        }

        //Refund Table: RefundTotalAmtAfterStoreCredit
        public string RefundTotalAmtAfterStoreCredit(string orderNumber)
        {
            string sql = "Select top 1 r.TotalAmtAfterStoreCredit from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "' order by RefundId desc";
            string refundTotalAmtAfterStoreCredit = DBSingleResultHelpers.DB_Method(sql);
            return refundTotalAmtAfterStoreCredit;
        }

        //Refund Table: RefundOrigin
        public string RefundOrigin(string orderNumber)
        {
            string sql = "Select r.RefundOrigin from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string refundOrigin = DBSingleResultHelpers.DB_Method(sql);
            return refundOrigin;
        }

        //Refund Table: RefundReason
        public string RefundReason(string orderNumber)
        {
            string sql = "Select r.RefundReason from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Inner Join dbo.Refund r On r.SellerOrderId = so.SellerOrderId " +
             "Where so.OrderNumber = '" + orderNumber + "'";
            string refundReason = DBSingleResultHelpers.DB_Method(sql);
            return refundReason;
        }

        //Refund table: Get last RefundId from an OrderNumber        
        public string GetLastRefundIdFromOrderNumber(string orderNumber)
        {
            string sql = "select top 1 RefundId from dbo.Refund where sellerOrderId in (select sellerOrderId from SellerOrder Where orderNumber = '" + orderNumber + "' order by RefundId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }
        //End of Refund Table





        //Start of SellerOrderProduct Table
        //SellerOrderProduct table: SellerProductCode from a seller order based on the ProductConditionId.
        public string SellerProductCode(string orderNumber, string productConditionId)
        {
            string sql = "Select sop.SellerProductCode From SellerOrder so Inner Join dbo.SellerOrderProduct sop on sop.SellerOrderId = so.SellerOrderId where so.ordernumber = '" + orderNumber + "' and sop.StoreProductConditionId = " + productConditionId;
            string sellerProductCode = DBSingleResultHelpers.DB_Method(sql);
            string value = "Null";
            //If query results are null, set to string = "Null".  
            if (sellerProductCode == "")
            {
                sellerProductCode = value;
            }
            return sellerProductCode;
        }
        //End of SellerOrderProduct Table

    }
}

