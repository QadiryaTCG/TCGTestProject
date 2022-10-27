using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    public class DirectOrderRefundQueries : StartBrowser
    {
       
        //Refund Table: RefundTypeId for direct orders.  Based on OrderId not OrderNumber
        public string GetRefundTypeId(string orderNumber)
        {
            string sql = "Select RefundTypeId from dbo.Refund Where OrderId in (select orderId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Refund Table: RefundStatusId for direct orders.  Based on OrderId not OrderNumber
        public string GetRefundStatusId(string orderNumber)
        {
            string sql = "Select RefundStatusId from dbo.Refund Where OrderId in (select orderId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Refund Table: RequestedAmt for direct orders.  Based on OrderId not OrderNumber
        public string GetRequestedAmt(string orderNumber)
        {
            string sql = "Select RequestedAmt from dbo.Refund Where OrderId in (select orderId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Refund Table: RefundNote for direct orders.  Based on OrderId not OrderNumber
        public string GetRefundNote(string orderNumber)
        {
            string sql = "Select RefundNote from dbo.Refund Where OrderId in (select orderId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Refund Table: ShippingAmt for direct orders.  Based on OrderId not OrderNumber
        public string GetShippingAmt(string orderNumber)
        {
            string sql = "Select ShippingAmt from dbo.Refund Where OrderId in (select orderId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Refund Table: RefundOrigin for direct orders.  Based on OrderId not OrderNumber
        public string GetRefundOrigin(string orderNumber)
        {
            string sql = "Select RefundOrigin from dbo.Refund Where OrderId in (select orderId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Refund Table: RefundReason for direct orders.  Based on OrderId not OrderNumber
        public string GetRefundReason(string orderNumber)
        {
            string sql = "Select RefundReason from dbo.Refund Where OrderId in (select orderId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

    }
}

