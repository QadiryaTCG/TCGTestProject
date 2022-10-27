using Framework.Base;
using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    public class SellerQueries : StartBrowser
    {
        //Start of queries that will get the rates charged for fees based on the SellerId or OrderId.
        //Determine the percentage rate a seller is charged for US Credit Card fees         
   
        public string GetSellerName(string sellerId)
        {
            string sql = "Select DisplayName from dbo.Seller Where SellerId = " + sellerId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetSellerKeyLowerCase(string sellerId)
        {
            string sql = "Select LOWER(SellerKey) from dbo.Seller Where SellerId = " + sellerId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;

        }

        public string GetSellerKeyUpperCase(string sellerId)
        {
            string sql = "Select Upper(SellerKey) from dbo.Seller Where SellerId = " + sellerId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetSellerStatusInd(string sellerId)
        {
            string sql = "select SellerStatusInd from dbo.seller  where sellerId = " + sellerId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Update the Marketplace seller level to 1
        public void SetMarketPlaceSellerLevel1(string sellerId)
        {
            string updateQuery = "update dbo.seller set sellerLevelid = 6 where sellerid = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update the Marketplace seller level to 2
        public void SetMarketPlaceSellerLevel2(string sellerId)
        {
            string updateQuery = "update dbo.seller set sellerLevelid = 12 where sellerid = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update the Marketplace seller level to 3
        public void SetMarketPlaceSellerLevel3(string sellerId)
        {
            string updateQuery = "update dbo.seller set sellerLevelid = 13 where sellerid = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update the Marketplace seller level to 4
        public void SetMarketPlaceSellerLevel4(string sellerId)
        {
            string updateQuery = "update dbo.seller set sellerLevelid = 14 where sellerid = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update seller name
        public void RenameSeller(string updatedName, string sellerId)
        {
            string updateQuery = "update seller set DisplayName = '" + updatedName + "' where sellerId = '" + sellerId + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }
    }
}


