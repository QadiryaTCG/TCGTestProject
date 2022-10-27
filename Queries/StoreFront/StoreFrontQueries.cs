using Framework.Helpers;

namespace TCGplayerUI.Queries.StoreFront
{
    class StoreFrontQueries
    {
        public string GetSiteName(string sellerId)
        {
            //Identifies the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string sql = "SELECT SiteName " + "\n" +
            "FROM Storefronts_" + envLower + ".dbo.StorefrontCustomizations sc " + "\n" +
            "Inner Join  Storefronts_" + envLower + ".dbo.StorefrontGameStores sgs ON sgs.StoreFrontId = sc.StorefrontId " + "\n" +
            "Inner Join TCGStoreQA.dbo.SellerProServicesSettings sps ON sps.StoreId = sgs.GameStoreId " + "\n" +
            "Where sps.SellerId = " + sellerId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
            
        }




    }
}
