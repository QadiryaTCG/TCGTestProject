using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    class LoginQueries : StartBrowser
    {
        //Updates the password to the default password in the aspnet_Membership table
        //userId = ProviderUserKey from user table 
        public void UpdatePassword(string userId)
        {
            string updateQuery = "Update dbo.aspnet_Membership set PasswordFormat = 0 , Password =  'P@ssw0rd!' where userid = '" + userId + "'";    
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }



   
}

