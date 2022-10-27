using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    public class DirectOrderQueries : StartBrowser
    {
        //Use to get the DirectOrder.DirectOrderId from a order number.  
        public string GetDirectOrderIdFromOrderNumber(string orderNumber)
        {
            string sql = "Select do.DirectOrderId  " + "\n" +
            "From tcgd.DirectOrder  do " + "\n" +
            "Inner Join dbo.[Order] o ON o.OrderId = do.OrderId " + "\n" +
            "Inner Join dbo.SellerOrder so ON so.OrderId = o.OrderId " + "\n" +
            "Where so.OrderNumber = '" + orderNumber + "'  ";
            string sellerOrderNumber = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderNumber;
        }

        //Use to get the DirectOrder.DirectOrderId from a DirectOrderNumber.  
        public string GetDirectOrderIdFromDirectOrderNumber(string directOrderNumber)
        {
            string sql = "Select DirectOrderId From tcgd.DirectOrder Where DirectOrderNumber = '" + directOrderNumber + "'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Use to get the DirectOrder.DirectOrderNumber from a DirectOrderId.  
        public string GetDirectOrderNumberFromDirectOrderId(string directOrderId)
        {
            string sql = "Select DirectOrderNumber From tcgd.DirectOrder Where DirectOrderId = " + directOrderId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Use to get the DirectOrder.ProductCount from a DirectOrderId.  
        public string GetProductCountFromDirectOrderId(string directOrderId)
        {
            string sql = "Select ProductCount From tcgd.DirectOrder Where DirectOrderId = " + directOrderId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Use to get the DirectOrder.OrderId from a DirectOrderId.  
        public string GetOrderIdFromDirectOrderId(string directOrderId)
        {
            string sql = "Select OrderId From tcgd.DirectOrder Where DirectOrderId = " + directOrderId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Use to get the DirectOrder.ProductValue from a DirectOrderId.  
        public string GetProductValueFromDirectOrderId(string directOrderId)
        {
            string sql = "Select ProductValue From tcgd.DirectOrder Where DirectOrderId = " + directOrderId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }
    }
}