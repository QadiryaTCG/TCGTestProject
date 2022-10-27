using Framework.Base;
using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    public class ProductQueries : StartBrowser
    {
        //Start of queries that will get the category name, product name, setname, and product type information for a specific productConditonId.
        public string GetCategoryNameSpacesRemoved(string productConditionId)
        {
        string sql = " SELECT top 1 LOWER(REPLACE(cat.CategoryName, ' ','-')) FROM dbo.StorePrice sp " + "\n" +
        "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId" + "\n" +
        "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
        "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId" + "\n" +
        "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID" + "\n" +
        "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId" + "\n" +
        "Where pc.ProductConditionId = " + productConditionId;
        string value = DBSingleResultHelpers.DB_Method(sql);
        return value;
        }

        public string GetProductNameSpacesRemoved(string productConditionId)
        {
            string sql = " SELECT top 1 LOWER(REPLACE(p.CleanProductName, ' ','-')) FROM dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId" + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId" + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID" + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId" + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetSetNameSpacesRemoved(string productConditionId)
        {
            string sql = " SELECT top 1 LOWER(REPLACE(sn.CleanSetName, ' ','-')) FROM dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId" + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId" + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID" + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId" + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetProductId(string productConditionId)
        {
            string sql = " SELECT top 1 p.ProductId FROM dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId" + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId" + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID" + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId" + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetProductTypeId(string productConditionId)
        {
            string sql = " SELECT top 1 p.ProductTypeId FROM dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId" + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId" + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID" + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId" + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public void UpdateProductToReleased(string productId)
        {
            string updateQuery = "update pdt.Product set ProductStatusId = 1 where ProductId = '" + productId + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }
    }
}


