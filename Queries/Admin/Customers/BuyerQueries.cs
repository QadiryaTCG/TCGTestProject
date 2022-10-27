using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    class BuyerQueries : StartBrowser
    {

        //Will get userid from ProviderUserName
        public string GetUserId(string buyerEmail)
        {
            string sql = "select userid from [User] where ProviderUserName in ('" + buyerEmail + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);            
            return value;            
        }

        //Will get externalUserId from ProviderUserName
        public string GetExternalUserId(string buyerEmail)
        {
            string sql = "select ExternalUserid from [User] where ProviderUserName in ('" + buyerEmail + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Will get ProviderUserName (email address) of the buyer from an order number
        public string GetProviderUserName(string orderNumber)
        {
            string sql = "select ProviderUserName from [User] where UserId in (select CreatedByUserId from dbo.SellerOrder where OrderNumber = '" + orderNumber + "')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Add a user to the Guest User security group
        public void AddBuyerToGuestUserSecurityGroup(string buyerEmail)
        {
            string updateQuery = "insert dbo.UserGroup (User_UserId, Group_GroupId) values ((Select UserId from dbo.[User] where ProviderUserName = '" + buyerEmail + "'),  (select GroupId from dbo.[Group] where Name = 'Guest Users'))";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }
}
