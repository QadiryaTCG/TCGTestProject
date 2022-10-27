using Framework.Base;
using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    public class PresaleQueries : StartBrowser
    {
        //Get most recent Presale Group created     

        public string GetLatestPresaleGroupCreated()
        {
            string sql = "select top 1 PreSaleGroupId from pdt.PresaleGroup order by PreSaleGroupId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Use the following 2 queries to delete a Presale Group in the DB.
        //The first query removes the products associated with the group.  The second deletes the group.
        public void RemovePresaleGroupFromProductId(string presaleGroupId)
        {
            string updateQuery = "update pdt.Product set PresaleGroupId = Null where ProductId in (select ProductId from pdt.Product where PresaleGroupId = " + presaleGroupId + ")";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Delete a presale group
        public void DeletePresaleGroup(string presaleGroupId)
        {
            string updateQuery = "delete from pdt.PresaleGroup where PresaleGroupId = " + presaleGroupId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }


        //Update the Release date for a PreSale Group
        public void UpdatePresaleShippingDate(string presaleShippingDate, string presaleGroupId)
        {
            string updateQuery = "Update pdt.PresaleGroup set PresaleShippingDate = '" + presaleShippingDate + "' where PresaleGroupId = " + presaleGroupId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }



        //Update the Release date for a PreSale Group
        public void UpdateReleaseDate(string releaseDate, string presaleGroupId)
        {
            string updateQuery = "Update pdt.PresaleGroup set ReleaseDate = '" + releaseDate + "' where PresaleGroupId = " + presaleGroupId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }
    }
}