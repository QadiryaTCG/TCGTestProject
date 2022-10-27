using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    class ProSellerQueries
    {
        public string ChannelId(string sellerId)
        {
            string sql = "select ChannelId from dbo.SellerProServicesSettings where SellerId = " + sellerId;
            string channelId = DBSingleResultHelpers.DB_Method(sql);
            return channelId;
        }


        public string StoreName(string sellerId)
        {
            string sql = "select StoreName from dbo.SellerProServicesSettings where SellerId = " + sellerId;
            string storeName = DBSingleResultHelpers.DB_Method(sql);
            return storeName;
        }

        public string StreetAddress(string sellerId)
        {
            string sql = "select StreetAddress from dbo.SellerProServicesSettings where SellerId = " + sellerId;
            string streetAddress = DBSingleResultHelpers.DB_Method(sql);
            return streetAddress;
        }


        public string City(string sellerId)
        {
            string sql = "select City from dbo.SellerProServicesSettings where SellerId = " + sellerId;
            string city = DBSingleResultHelpers.DB_Method(sql);
            return city;
        }


        public string State(string sellerId)
        {
            string sql = "select State from dbo.SellerProServicesSettings where SellerId = " + sellerId;
            string state = DBSingleResultHelpers.DB_Method(sql);
            return state;
        }


        public string Zip(string sellerId)
        {
            string sql = "select Zip from dbo.SellerProServicesSettings where SellerId = " + sellerId;
            string zip = DBSingleResultHelpers.DB_Method(sql);
            return zip;
        }

        public void EnableInStorePickUp(string sellerId)
        {
            string updateQuery = "DECLARE @SellerId BIGINT " +
            "SELECT @SellerId = " + sellerId +
            "IF EXISTS(select* from dbo.ShippingSellerPrice where ShippingMethodId  = 4 and ShippingCategoryId = 1 and SellerId = @SellerId) " +
            "BEGIN " +
            "UPDATE dbo.ShippingSellerPrice SET Price = 0.00, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId = 4 and ShippingCategoryId = 1 and SellerId = @SellerId) " +
            "END " +
            "ELSE BEGIN " +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold) " +
            "VALUES(1, 4, @SellerId, NULL, 0.00, 'INSTOREPICKUP', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'),	NULL,	1,	0,	0,	NULL) " +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        public void EnableIsPayLater(string sellerId)
        {
            string updateQuery = "UPDATE dbo.SellerProServicesSettings SET IsPayLaterEnabled = 1 where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        public void DisableIsPayLater(string sellerId)
        {
            string updateQuery = "UPDATE dbo.SellerProServicesSettings SET IsPayLaterEnabled = 0 where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        public void EnableIsPayNow(string sellerId)
        {
            string updateQuery = "UPDATE dbo.SellerProServicesSettings SET IsPayNowEnabled = 1 where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        public void DisableIsPayNow(string sellerId)
        {
            string updateQuery = "UPDATE dbo.SellerProServicesSettings SET IsPayNowEnabled = 0 where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }
}