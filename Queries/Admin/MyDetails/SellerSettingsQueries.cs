using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    public class SellerSettingsQueries : StartBrowser
    {

        public string GetSellerLevel(string sellerId)
        {            
            string sql = "select sl.Name from dbo.sellerLevel sl inner join dbo.Seller s On sl.SellerLevelId = s.SellerLevelId where sellerId = " + sellerId;
            string x = DBSingleResultHelpers.DB_Method(sql);
            return x;
        }

        public void RefundDailyCountQuery(string sellerId)
        {
            string updateQuery = "update dbo.Seller set DailyRefundCount = 0 where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }
}
