using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    public class OrderQueries : StartBrowser
    {
        //Gets the SellerStatusOrderId of an order.  Use prior to running API jobs.
        public int SellerOrderStatusId(string orderNumber)
        {
            string sql = "select Top 1 so.SellerOrderStatusId " + "from dbo.SellerOrder so " +
            "Inner Join dbo.SellerOrderFee sof ON sof.SellerOrderId = so.SellerOrderId " + "where OrderNumber = '" + orderNumber + "'";
            string sellerOrderStatusId = DBSingleResultHelpers.DB_Method(sql);
            int num = 0;
            //Need to convert SellerOrderStatusId to an interger for use later on.  If Null, convert it to 0.
            if (sellerOrderStatusId == "")
            {
                num = 0;
            }
            else
            {
                num = int.Parse(sellerOrderStatusId);
            }          
            return num;
        }


        //Gets the last order that was created for a specific seller.
        public string GetLastOrderNumberFromSpecificSeller(string sellerId)
        {
            string sql = "select top 1 OrderNumber from SellerOrder where SellerId = " + sellerId + " and SellerOrderStatusId in (12, 13, 17) and IsDirect != 1 and PresaleStatusId is Null order by SellerOrderId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get orders without shipping information for a specific seller.  Orders are within a range of 1 to 10 weeks old.
        //Direct orders are ignored.
        //Order earlier than 1 week may be data another tester is using.  
        //Order greater than 12 weeks will not appear in the order list.  They will have aged out.
        public string GetOrderNumberFromSpecificSellerFromOrderList(string sellerId)
        {
            string sql = "select top 1 so.OrderNumber from dbo.SellerOrder so inner join dbo.seller s on s.SellerId = so.SellerId  " +
            "where so.ShippingMethodId is NULL and s.SellerId = " + sellerId + " and so.SellerOrderStatusId = 17 and so.ProductAmt < '200.00' and so.IsDirect = 0 " +
            " and so.CreatedAt > (select dateadd(week, -10, getdate())) " +
            "and so.CreatedAt < (select dateadd(week, -1, getdate())) order by so.SellerOrderId desc";
            string orderNumber = DBSingleResultHelpers.DB_Method(sql);
            return orderNumber;
        }

        //Get orders without shipping information.  Will be returned for any seller.  Orders are within a range of 1 to 10 weeks old.  
        //Direct orders are ignored.
        //Order earlier than 1 week may be data another tester is using.  
        //Order greater than 12 weeks will not appear in the order list.  They will have aged out.
        public string GetOrderNumberFromAnySellerFromOrderList()
        {
            string sql = "select top 1 so.OrderNumber from dbo.SellerOrder so inner join dbo.seller s on s.SellerId = so.SellerId  " +
            "where so.ShippingMethodId is NULL and so.SellerOrderStatusId = 17 and so.ProductAmt < '200.00' and so.IsDirect = 0 " +
            " and so.CreatedAt > (select dateadd(week, -10, getdate())) " +
            "and so.CreatedAt < (select dateadd(week, -1, getdate())) order by so.SellerOrderId desc";
            string orderNumber = DBSingleResultHelpers.DB_Method(sql);
            return orderNumber;
        }

        //Get the seller's ProviderUserKey for specific seller order.   
        public string GetSellerProviderUserKeyForSpecificOrderNumber(string orderNumber)
        {
            string sql = "select u.ProviderUserKey   " +
                "from dbo.[User] u  " +
                "inner join UserSeller us on us.User_UserId = u.UserId  " +
                "inner join Seller s on s.SellerId = us.Seller_SellerId   " +
                "inner join dbo.SellerOrder so on so.SellerId = s.SellerId  " +
                "where so.OrderNumber = '" + orderNumber + "'";
            string ProviderUserKey = DBSingleResultHelpers.DB_Method(sql);
            return ProviderUserKey;
        }



        //Get the seller's login id (email) for specific seller order.   
        public string GetSellerEmailForSpecificOrderNumber(string orderNumber)
        {
            string sql = "select u.ProviderEmailAddress   " +
                "from dbo.[User] u  " +
                "inner join UserSeller us on us.User_UserId = u.UserId  " +
                "inner join Seller s on s.SellerId = us.Seller_SellerId   " +
                "inner join dbo.SellerOrder so on so.SellerId = s.SellerId  " +
                "where so.OrderNumber = '" + orderNumber + "'";
            string ProviderEmailAddress = DBSingleResultHelpers.DB_Method(sql);
            return ProviderEmailAddress;
        }

        //Use to get the SellerOrder.OrderNumber from a direct order.  (Where there was only 1 SellerOrderNumber per Direct order.)
        public string GetSellerOrderNumberFromDirectOrderNumber(string directOrderNumber)
        {
            string sql = "Select so.OrderNumber " + "\n" +
            "From dbo.SellerOrder so " + "\n" +
            "Inner Join dbo.[Order] o ON o.OrderId = so.OrderId " + "\n" +
            "Inner Join tcgd.DirectOrder do ON do.OrderId = o.OrderId " + "\n" +
            "Where do.DirectOrderNumber = '" + directOrderNumber + "'  ";
            string sellerOrderNumber = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderNumber;
        }

        //Use to get the SellerOrder.OrderId from a direct order.  (Where there was only 1 SellerOrderNumber per Direct order.)
        public string GetOrderIdFromOrderNumber(string orderNumber)
        {
            string sql = "Select OrderId From dbo.SellerOrder Where OrderNumber = '" + orderNumber + "'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Use to get the SellerOrder.SellerOrderId from an OrderNumber.  
        public string GetSellerOrderIdFromOrderNumber(string orderNumber)
        {
            string sql = "Select SellerOrderId From dbo.SellerOrder Where OrderNumber = '" + orderNumber + "'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }
        
        //Update the ValidateAt and TrackingSvcStatusId in the TrackingNumber table          
        public string UpdateValidatedDateTrackingSvcStatusIdInTrackingNumberTable(string orderNumber)
        {
            string sql = "update TrackingNumber set ValidatedDate = GETUTCDATE(), TrackingSvcStatusId = 1  where SellerOrderId in (Select SellerOrderId from SellerOrder where OrderNumber = '" + orderNumber + "')";
            string sellerOrderNumber = DBSingleResultHelpers.DB_Method(sql);
            return sellerOrderNumber;
        }

        //Update OrderDate field in the dbo.Order table
        public void UpdateOrderDateInOrderTable(string newOrderDate, string orderNumber)
        {
            string updateQuery = "update dbo.[Order] set OrderDate = '" + newOrderDate + " 00:00:00.000' where OrderId in (select OrderId from sellerorder where OrderNumber = '" + orderNumber + "')";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Use to see if the SellerOrder is in the OrderWithoutTracking table
        public string IsSellerOrderInOrderWithoutTrackingTable(string sellerOrderId)
        {
            string sql = "select count (*) from OrderWithoutTracking where sellerOrderId = " + sellerOrderId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Update LastChecked field in the OrderWithoutTracking table
        public void UpdateLastCheckedInOrderWithoutTrackingTable(string newDate, string sellerOrderId)
        {
            string updateQuery = "update dbo.OrderWithoutTracking set LastChecked = '" + newDate + " 00:00:00.000' where OrdersWithoutTrackingId in (select OrdersWithoutTrackingId from OrderWithoutTracking where SellerOrderId = '" + sellerOrderId + "')";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Delete any entries where LastChecked is older than 1 week in the OrderWithoutTracking table
        public void DeleteOldEntiresInOrderWithoutTrackingTable(string date)
        {
            string updateQuery = "delete from OrderWithoutTracking where  LastChecked < '" + date +" 00:00:00.000'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Get all the OrderNumbers from the dbo.SellerOrderTable based on an OrderId from an OrderNumber
        public string[] SellerOrdersWithinAnOrder(string orderNumber)
        {
            string sql = "select OrderNumber from dbo.SellerOrder where orderId in (select orderId from SellerOrder where orderNumber = '" + orderNumber + "') order by SellerId asc";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
        }

    }
}