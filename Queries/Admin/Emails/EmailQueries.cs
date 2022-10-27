using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    class EmailQueries
    {
        ///Update EmailStatusId < 3 in the dbo.Email table.  This will clear out the queue for the Email Render and Send job so it completes.
        public void UpdateEmailsToSent()
        {
            string updateQuery = "Update dbo.Email set EmailStatusId = 3 where EmailStatusId < 3";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }
}
