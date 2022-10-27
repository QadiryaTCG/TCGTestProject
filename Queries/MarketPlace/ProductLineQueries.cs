using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
    class ProductLineQueries
    {
        public string[] GetProductLineBySeller(string sellerId)
        {
            string sql = "SELECT cat.CategoryName" + "\n" +
                          "FROM	dbo.StorePrice sp " + "\n" +
                          "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId" + "\n" +
                          "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
                          "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId" + "\n" +
                          "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID" + "\n" +
                          "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId" + "\n" +
                          "INNER JOIN PDT.ProductType pt ON pt.ProductTypeId = p.ProductTypeID" + "\n" +
                          "INNER JOIN PDT.ProductStatus ps ON ps.ProductStatusId = p.ProductStatusId" + "\n" +
                          "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId" + "\n" +
                          "Inner Join dbo.AvailableInventory ai ON ai.StoreProductID = pc.ProductId and ai.SellerId = sp.SellerId and ai.ChannelId = sp.ChannelId" + "\n" +
                          "INNER JOIN dbo.ShippingSellerPrice ssp ON s.SellerId = ssp.SellerId" + "\n" +
                          "AND p.ShippingCategoryId = ssp.ShippingCategoryId" + "\n" +
                          "Where sp.Quantity > 0 and s.SellerId ='" + sellerId + "'";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
        }
    }
}
