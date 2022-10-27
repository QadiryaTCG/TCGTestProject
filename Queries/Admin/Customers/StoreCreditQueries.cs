using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    class StoreCreditQueries : StartBrowser
    {

        //Will get store credit value for the user.  If none, it returns 0.00.
        public string StoreCreditBalance(string buyerEmail)
        {
            string sql = "Select  CAST(ISNULL(SUM(Amt),'0.00') AS DECIMAL(8,2)) AS 'StoreCreditAmount' " + "\n" +
                "FROM StoreCreditQueue scq " + "\n" +
                "RIGHT JOIN[user] u ON u.userid = scq.UserId " + "\n" +
                "WHERE u.providerusername = '" + buyerEmail + "'";
            string storeCreditAmount = DBSingleResultHelpers.DB_Method(sql);            
            return storeCreditAmount;
            
        }

        //Deletes the buyer's store credit balance if there is one.
        public void SetStoreCreditBalanceToZero(string buyerEmail)
        {
            string updateQuery = "DELETE FROM storecreditqueue WHERE UserId in (select UserId from dbo.[User] where ProviderUserName = '" + buyerEmail + "')";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Adds Store Credit for a buyer
        public void GiveStoreCredit(string buyerEmail, string amount)
        {
            string updateQuery = "Declare @ProviderUserName VARCHAR (250) " + "\n" +
            "SELECT @ProviderUserName = '" + buyerEmail + "' " + "\n" +
            "INSERT INTO dbo.storecreditqueue(UserId, Amt, Note, CreatedByUserId, CreatedAt, UpdatedByUserId, UpdatedAt, StoreCreditReasonId, StoreCreditQueueStatusId)" + "\n" +
            "Select u.UserId, " + amount + ", 'AutomationTest', '-1000', getutcdate(), NULL, NULL, 1, 2" + "\n" +
            "FROM dbo.[User] u" + "\n" +
            "WHERE u.ProviderUserName = @ProviderUserName";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }
}
