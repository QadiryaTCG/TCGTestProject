using Framework.Base;
using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    public class BuylistQueries : StartBrowser
    {
        //Get ProductConditionId a seller has in the BYL.BuyListProduct table     
        public string GetBuylistProductConditionId(string sellerId)
        {
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string env = envData["env"];

            string sql = "SELECT Top 1 ProductConditionId FROM [TCGStore" + env + "].[BYL].[BuyListProduct] where SellerId = " + sellerId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get ProductConditionId a seller has in thier Stage Pricing abd also has a High Price Value   
        public string GetBuylistProductConditionIdWithHighPriceInStagedInventory(string sellerId)
        {
            string sql = "SELECT top 1 blpr.ProductConditionId from byl.StagedPricing sp " + "\n" +
            "Inner Join byl.BuyListPrice blpr On blpr.ProductConditionId = sp.ProductConditionId " + "\n" +
            "Inner Join byl.StagedPricingUpload spu On spu.StagedPricingUploadId = sp.StagedPricingUploadId " + "\n" +
            "Inner Join seller s On s.SellerId = spu.SellerId " + "\n" +
            "Inner Join pdt.ProductCondition pc On pc.ProductConditionId = blpr.ProductConditionId " + "\n" +
            "Inner Join pdt.Product p On p.ProductId = pc.ProductConditionId " + "\n" +
            "where s.SellerId = " + sellerId + " " + "\n" +
            "and blpr.HighPrice is not Null";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get Buylist High Price for a product based on ProductConditionId
        public string GetBuylistHighPrice(string productConditionId)
        {
            string sql = "SELECT HighPrice FROM byl.BuyListPrice where ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get ProductName based on the ProductConditionId   
        public string GetProductName(string productConditionId)
        {
            string sql = "Select p.ProductName " + "\n" +
            "From PDT.ProductCondition pc " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get CategoryName based on the ProductConditionId   
        public string GetCategoryName(string productConditionId)
        {
            string sql = "Select cat.CategoryName " + "\n" +
            "From PDT.ProductCondition pc " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get SetName based on the ProductConditionId   
        public string GetSetName(string productConditionId)
        {
            string sql = "Select sn.SetName " + "\n" +
            "From PDT.ProductCondition pc " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get Condition based on the ProductConditionId   
        public string GetCondition(string productConditionId)
        {
            string sql = "Select c.ConditionName " + "\n" +
            "From PDT.ProductCondition pc " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get SuperConditionId based on the ProductConditionId  (Foil or non foil) 
        public string GetSuperConditionId (string productConditionId)
        {
            string sql = "Select c.SuperConditionId " + "\n" +
            "From PDT.ProductCondition pc " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get Current Withholdings for seller 
        public string GetCurrentWithholdings(string sellerId)
        {
            string sql = "select BuyListWithholdings from byl.SellerSettings where SellerId = " + sellerId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Update Withholding Method to a flat rate for a seller
        public void UpdateBuyListWithholdingMethodToFlatRate(string sellerId)
        {
            string updateQuery = "update byl.SellerSettings set BuyListWithholdingMethod = 0 where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update Withholding Method to a percentage rate for a seller
        public void UpdateBuyListWithholdingMethodToPercentageRate(string sellerId)
        {
            string updateQuery = "update byl.SellerSettings set BuyListWithholdingMethod = 1 where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update BuyList Withholding Amount for a seller
        public void UpdateBuyListWithholdingAmount(string amount, string sellerId)
        {
            string updateQuery = "update byl.SellerSettings set BuyListWithholdingAmt = '" + amount + "' where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Get BuyListOfferId from byl.BuyListOffer table using the OfferNumber
        public string UpdateBuyListWithholdingAmount(string buylistNumber)
        {
            string sql = "select BuyListOfferId from byl.BuyListOffer where OfferNumber = '" + buylistNumber + "'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

    }
}