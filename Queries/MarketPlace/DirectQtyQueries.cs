using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
    public class DirectQtyQueries
    {
        public string[] GetZeroQtyDirectItemInfoArray()
        {
            string selectQuery = "SELECT top 1 p.ProductName, s.DisplayName As 'Seller Name', s.SellerKey, s.SellerID "+ "\n" +
                                 "FROM dbo.StorePrice sp " + "\n" +
                                 "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId" + "\n" +
                                 "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
                                 "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId" + "\n" +
                                 "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID" + "\n" +
                                 "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId" + "\n" +
                                 "INNER JOIN PDT.ProductType pt ON pt.ProductTypeId = p.ProductTypeID" + "\n" +
                                 "INNER JOIN PDT.ProductStatus ps ON ps.ProductStatusId = p.ProductStatusId" + "\n" +
                                 "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId" + "\n" +
                                 "INNER JOIN dbo.ShippingSellerPrice ssp ON s.SellerId = ssp.SellerId" + "\n" +
                                 "AND ssp.ShippingCategoryId = p.ShippingCategoryId" + "\n" +
                                 "AND ssp.ShippingMethodId = 5" + "\n" +  //Free shipping
                                 "AND ssp.IsActive = 0" + "\n" +//Free shipping:  1 is active 0 is inactive
                                 "And ssp.Threshold <= sp.Price" + "\n" + //product price is over free shipping threshold
                                 "Inner Join TCGD.DirectInventory di  ON di.ProductConditionId = pc.ProductConditionId" + "\n" +
                                 "where s.SellerStatusInd = 'Live' and s.Isdirect = 1 and di.QtyAvailable = 0 and sp.Quantity > 0 and sp.Price < 35" + "\n" +
                                 "and sp.ChannelId = 0" + "\n" +// not My Store Price, needed for MP carts
                                 "and ps.Name = 'Released Product' " + "\n" + //not presale
                                 "and p.FreeShippingEligible = 1 " + "\n" +//product eligiable for FreeShipping
                                 "and p.ShippingCategoryId = 1"; //product is a card
                                   
            string[] productInfo = DBMultipleResultsHelpers.DB_MethodReturnArray(selectQuery);
            Console.WriteLine("Database Connection is complete!");
            return productInfo;
        }

  
    }
}
