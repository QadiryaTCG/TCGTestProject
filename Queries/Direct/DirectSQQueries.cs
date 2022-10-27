using Framework.Base;
using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    public class DirectSQQueries : StartBrowser
    {
          
        // Get shipping queue product count for a specific shipping queue number
        public string GetSQProductCount(string sqNumber)
        {
            string sql = "SELECT distinct" + "\n" +
                         "sq.ProductCount AS 'Number of Cards in queue' " + "\n" +
                         "FROM TCGD.DirectOrder do " + "\n" +
                         "Join TCGD.ShippingQueue sq ON do.ShippingQueueId = sq.ShippingQueueId " + "\n" +
                         "Join dbo.[Order] o ON do.OrderId = o.OrderId " + "\n" +
                         "Join dbo.[User] u ON o.CreatedByUserId = u.UserId " + "\n" +
                         "Left Join dbo.UserSubscriber us ON o.CreatedByUserId = us.UserId " + "\n" +
                         "WHERE sq.ShippingQueueNumber = '" + sqNumber + "' ";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        // Get shipping queue order count for a specific shipping queue number
        public string GetSQOrderCount(string sqNumber)
        {
            string sql = "SELECT distinct" + "\n" +
                         "sq.OrderCount" + "\n" +
                         "FROM TCGD.DirectOrder do " + "\n" +
                         "Join TCGD.ShippingQueue sq ON do.ShippingQueueId = sq.ShippingQueueId " + "\n" +
                         "Join dbo.[Order] o ON do.OrderId = o.OrderId " + "\n" +
                         "Join dbo.[User] u ON o.CreatedByUserId = u.UserId " + "\n" +
                         "Left Join dbo.UserSubscriber us ON o.CreatedByUserId = us.UserId " + "\n" +
                         "WHERE sq.ShippingQueueNumber = '" + sqNumber + "' ";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        // Get package weight for a specific direct order 
        public string GetPackageWeight(string directOrderNumber)
        {
            string sql = "SELECT PackageWeight" + "\n" +
                           "FROM TCGD.DirectOrder " + "\n" +
                           "WHERE DirectOrderNumber = '" + directOrderNumber + "' ";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;

        }

        // Get postageId for a specific direct order
        public string GetPostageId(string directOrderNumber)
        {
            string sql = "SELECT PostageId" + "\n" +
                           "FROM TCGD.DirectOrder " + "\n" +
                           "WHERE DirectOrderNumber = '" + directOrderNumber + "' ";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;

        }

        // Get package type name 
        public string GetPackageType()
        {
            string sql = "SELECT Name" + "\n" +
                           "FROM SHP.PackageType " + "\n" +
                           "ORDER BY PackageTypeId DESC";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        // Get postageId for a package tier with specific data (tracking code and international tracking code)
        public string GetPostageIdofNewPackageTier(string trackingCode, string intlTrackingCode)
        {
            string sql = "SELECT PostageId " + "\n" +
                         "FROM SHP.Postage " + "\n" +
                         "WHERE CreatedByUserId = '1516409'and TrackingCode = '" + trackingCode + "' " +"\n" + 
                         "and InternationalTrackingCode = '" + intlTrackingCode + "'" + "\n" +
                         "ORDER BY PostageId DESC";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

       

    }
}


