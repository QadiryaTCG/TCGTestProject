using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    class AddressQueries : StartBrowser
    {

        //Get ShippingAddress1
        public string GetShippingAddress1(string buyerEmail)
        {
            string sql = "select ShippingAddress1 from [User] where ProviderUserName in ('" + buyerEmail + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);            
            return value;
            
        }

        //Get ShippingAddress2
        public string GetShippingAddress2(string buyerEmail)
        {
            string sql = "select ShippingAddress2 from [User] where ProviderUserName in ('" + buyerEmail + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;

        }

        //Get ShippingCity
        public string GetShippingCity(string buyerEmail)
        {
            string sql = "select ShippingCity from [User] where ProviderUserName in ('" + buyerEmail + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;

        }

        //Get ShippingState
        public string GetShippingState(string buyerEmail)
        {
            string sql = "select ShippingState from [User] where ProviderUserName in ('" + buyerEmail + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;

        }

        //Get ShippingZip
        public string GetShippingZip(string buyerEmail)
        {
            string sql = "select ShippingZipcode from [User] where ProviderUserName in ('" + buyerEmail + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;

        }


    }
}
