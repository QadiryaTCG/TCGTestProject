using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    public class ShippingQueries : StartBrowser
    {
        //*************Start of dbo.SysParam table*************
        //Get the Minimum Shipping Fee from the dbo.SysParam table
        public string GetMinimumShippingFee()
        {
            string sql = "select ParamValue from dbo.SysParam where ParamName = 'Minimum Shipping Fee'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get the Free Shipping Threshold from the dbo.SysParam table
        public string GetFreeShippingThreshold()
        {
            string sql = "select ParamValue from dbo.SysParam where ParamName = 'Free Shipping Threshold'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }   
        //*************End of dbo.SysParam table*************


        //*************Start of Standard Shipping*************

        //Update Standard Shipping price for small products
        public void UpdateStandardShipping(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 1 and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 1 and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 1, @SellerId,  'US', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update Standard Shipping price for medium sized products
        public void UpdateStandardShippingMedium(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 1 and ShippingCategoryId = 2 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 1 and ShippingCategoryId = 2 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 1, @SellerId,  'US', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update Standard Shipping price for large sized products
        public void UpdateStandardShippingLarge(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 1 and ShippingCategoryId = 3 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 1 and ShippingCategoryId = 3 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 1, @SellerId,  'US', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update Standard Shipping price for extra large sized products
        public void UpdateStandardShippingExtraLarge(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 1 and ShippingCategoryId = 4 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 1 and ShippingCategoryId = 4 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 1, @SellerId,  'US', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Get the standard ShippingSellerPriceId from the ShippingSellerPrice table for small products
        public string StandardShippingSellerPriceId(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 1 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
            string standardShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return standardShippingSellerPriceId;
        }

        //Get the standard ShippingSellerPriceId from the ShippingSellerPrice table for medium products
        public string StandardShippingSellerPriceIdMedium(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 1 and ssp.ShippingCategoryId = 2 and SellerId = " + sellerId + " and IsActive = 1";
            string standardShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return standardShippingSellerPriceId;
        }

        //Get the standard ShippingSellerPriceId from the ShippingSellerPrice table for large products
        public string StandardShippingSellerPriceIdLarge(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 1 and ssp.ShippingCategoryId = 3 and SellerId = " + sellerId + " and IsActive = 1";
            string standardShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return standardShippingSellerPriceId;
        }

        //Get the standard ShippingSellerPriceId from the ShippingSellerPrice table for extra large products
        public string StandardShippingSellerPriceIdExtraLarge(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 1 and ssp.ShippingCategoryId = 4 and SellerId = " + sellerId + " and IsActive = 1";
            string standardShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return standardShippingSellerPriceId;
        }

        //Get the standard ShippingPrice from the ShippingSellerPrice table for small products
        public string StandardShippingSellerPrice(string sellerId)
        {
            string sql = "Select CONVERT(varchar, ssp.Price) AS ShippingPrice from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 1 and ssp.ShippingCategoryId = 1 and sellerId = " + sellerId + " and IsActive = 1";
            string standardShippingSellerPrice = DBSingleResultHelpers.DB_Method(sql);
            return standardShippingSellerPrice;
        }

        //Get the standard CartDisplayText from the ShippingSellerPrice table  (This is currently the same for all product categories.)
        public string StandardShippingSellerCartDisplayText(string sellerId)
        {
            string sql = "Select sm.CartDisplayText from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 1 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
            string standardShippingSellerDisplayText = DBSingleResultHelpers.DB_Method(sql);
            return standardShippingSellerDisplayText;
        }
        //*************End of Standard Shipping*************


        //*************Start of Expedited Shipping*************

        //Update expedited shipping price for small products
        public void UpdateExpeditedShipping(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 2 and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 2 and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 2, @SellerId,  'US', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update expedited shipping price for medium products
        public void UpdateExpeditedShippingMedium(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 2 and ShippingCategoryId = 2 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 2 and ShippingCategoryId = 2 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 2, @SellerId,  'US', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update expedited shipping price for large products
        public void UpdateExpeditedShippingLarge(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 2 and ShippingCategoryId = 3 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 2 and ShippingCategoryId = 3 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 2, @SellerId,  'US', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        ///Update expedited shipping price for extra large products
        public void UpdateExpeditedShippingExtraLarge(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 2 and ShippingCategoryId = 4 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 2 and ShippingCategoryId = 4 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 2, @SellerId,  'US', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update expedited shipping price for small products Canada
        public void UpdateExpeditedShippingSmallCanada(string sellerId, string price)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Price SMALLMONEY = '" + price + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 3 and CountryCode = 'CA' and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET Price = @Price, UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = Null WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId  = 3 and ShippingCategoryId = 1 and CountryCode = 'CA' and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 3, @SellerId,  'CA', @Price, 'TCGFIRSTCLASS', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, NULL FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Get the expedited ShippingSellerPriceId from the ShippingSellerPrice table for small products
        public string ExpeditedShippingSellerPriceId(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 1 and SellerId = ('" + sellerId + "') and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }

        //Get the expedited ShippingSellerPriceId from the ShippingSellerPrice table for medium products
        public string ExpeditedShippingSellerPriceIdMedium(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 2 and SellerId = " + sellerId + " and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }

        //Get the expedited ShippingSellerPriceId from the ShippingSellerPrice table for large products
        public string ExpeditedShippingSellerPriceIdLarge(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 3 and SellerId = " + sellerId + " and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }

        //Get the expedited ShippingSellerPriceId from the ShippingSellerPrice table for Direct under Threshold
        public string ExpeditedShippingSellerPriceIdDirectUnderThreshold()
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 1 and SellerId = ('-1') and IsOverThreshold = 0 and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }

        //Get the expedited ShippingSellerPriceId from the ShippingSellerPrice table for Direct Over Threshold
        public string ExpeditedShippingSellerPriceIdDirectOverThreshold()
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 1 and SellerId = ('-1') and IsOverThreshold = 1 and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }

        //Get the expedited ShippingSellerPriceId from the ShippingSellerPrice table for extra large products
        public string ExpeditedShippingSellerPriceIdExtraLarge(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 4 and SellerId = " + sellerId + " and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }

        //Get the expedited ShippingSellerPriceId from the ShippingSellerPrice table for small products Canada
        public string ExpeditedShippingSellerPriceIdSmallCanada(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 3 and ssp.ShippingCategoryId = 1 and CountryCode = 'CA' and SellerId = ('" + sellerId + "') and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }

        //Get the expedited CartDisplayText from the ShippingSellerPrice table  (This is currently the same for all product categories.)
        public string ExpeditedShippingSellerCartDisplayText(string sellerId)
        {
            string sql = "Select sm.CartDisplayText from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
            string expeditedShippingSellerDisplayText = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerDisplayText;
        }

        //Get the expedited ShippingSellerPrice from the ShippingSellerPrice table for small products
        public string ExpeditedDirectShippingPriceUnderThreshold()
        {
            string sql = "Select CONVERT(varchar, ssp.Price) AS ShippingPrice from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 1 and IsOverThreshold = 0 and SellerId = '-1' and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }

        //Get the expedited ShippingSellerPrice from the ShippingSellerPrice table for small products
        public string ExpeditedDirectShippingPriceOverThreshold()
        {
            string sql = "Select CONVERT(varchar, ssp.Price) AS ShippingPrice from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 2 and ssp.ShippingCategoryId = 1 and IsOverThreshold = 1 and SellerId = '-1' and IsActive = 1";
            string expeditedShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return expeditedShippingSellerPriceId;
        }
        //*************End of Expedited Shipping*************


        //*************Start of In Store Shipping*************
        //Get the in store ShippingSellerPriceId from the ShippingSellerPrice table
        public string InStoreShippingSellerPriceId(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 4 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
            string inStoreShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return inStoreShippingSellerPriceId;
        }

        ////Get the in store shipping price from the ShippingSellerPrice table
        //public string InStoreShippingSellerPrice(string sellerId)
        //{
        //    string sql = "Select CONVERT(varchar, ssp.Price) AS ShippingPrice from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 4 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
        //    string inStoreShippingSellerPrice = DBSingleResultHelpers.DB_Method(sql);
        //    return inStoreShippingSellerPrice;
        //}

        //Get the in store CartDisplayText from the ShippingSellerPrice table
        public string InStoreShippingSellerCartDisplayText(string sellerId)
        {
            string sql = "Select sm.CartDisplayText from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 4 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
            string inStoreShippingSellerDisplayText = DBSingleResultHelpers.DB_Method(sql);
            return inStoreShippingSellerDisplayText;
        }
        //*************End of In Store Shipping*************


        //*************Start of Free Shipping*************
        //Update the free shipping Threshold and active free shipping
        public void UpdateFreeShippingThresholdAndActiveFreeShipping(string sellerId, string threshold)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @Threshold SMALLMONEY = '" + threshold + "'" + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 5 and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET  Price = '0.00', UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'),IsActive = 1, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = @Threshold WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId = 5 and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "Values(1, 5, @SellerId,  'US', '0.00', 'FREESHIPPING', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 1, 0, 0, @Threshold)"  + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Deactive free shipping
        public void DeactivateFreeShipping(string sellerId)
        {
            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +

            "IF EXISTS(select top 1 * from dbo.ShippingSellerPrice where ShippingMethodId  = 5 and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "BEGIN" + "\n" +
            "UPDATE dbo.ShippingSellerPrice SET  Price = '0.00', UpdatedAt = getutcdate(), UpdatedByUserID = (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'),IsActive = 0, IsOverThreshold = 0, IsInviteOnly = 0, Threshold = 0.00 WHERE ShippingSellerPriceId = (select ShippingSellerPriceId from dbo.ShippingSellerPrice where ShippingMethodId = 5 and ShippingCategoryId = 1 and SellerId = @SellerId)" + "\n" +
            "END" + "\n" +
            "ELSE BEGIN" + "\n" +
            "INSERT INTO dbo.ShippingSellerPrice(ShippingCategoryId, ShippingMethodId, SellerId, CountryCode, Price, ShippingMethodCode, CreatedAt, UpdatedAt, CreatedByUserId, UpdatedByUserId, IsActive, IsOverThreshold, IsInviteOnly, Threshold)" + "\n" +
            "SELECT ShippingCategoryId, 5, @SellerId,  'US', '0.00', 'FREESHIPPING', getutcdate(), getutcdate(), (select UserId from dbo.[User] where ProviderUserName = 'admin@auto.com'), NULL, 0, 0, 0, 0.00 FROM ShippingCategory" + "\n" +
            "END";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Get the free ShippingSellerPriceId from the ShippingSellerPrice table
        public string FreeShippingSellerPriceId(string sellerId)
        {
            string sql = "Select ssp.ShippingSellerPriceId from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 5 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
            string freeShippingSellerPriceId = DBSingleResultHelpers.DB_Method(sql);
            return freeShippingSellerPriceId;
        }

        //Get the free shipping CartDisplayText from the ShippingSellerPrice table
        public string FreeShippingSellerCartDisplayText(string sellerId)
        {
            string sql = "Select sm.CartDisplayText from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 5 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
            string freeShippingSellerDisplayText = DBSingleResultHelpers.DB_Method(sql);
            return freeShippingSellerDisplayText;
        }

        //Get the free shipping Threshold from the ShippingSellerPrice table
        public string FreeShippingSellerThreshold(string sellerId)
        {
            string sql = "Select CONVERT(Decimal(8,2), ssp.Threshold) AS Threshold from dbo.ShippingSellerPrice ssp Inner Join dbo.Shippingmethod sm ON sm.ShippingMethodId = ssp.ShippingMethodId where ssp.ShippingMethodId = 5 and ssp.ShippingCategoryId = 1 and SellerId = " + sellerId + " and IsActive = 1";
            string freeShippingSellerThreshold = DBSingleResultHelpers.DB_Method(sql);
            return freeShippingSellerThreshold;
        }  
        //*************End of Free Shipping*************

    }
}