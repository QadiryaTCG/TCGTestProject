using Framework.Base;
using Framework.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries
{
    class DirectBuylistQueries : StartBrowser
    {
        public string GetSellerWithLargeBuylist()
        {
            string sql = "SELECT top 1 s.DisplayName, SUM (bpsi.Quantity) AS BuylistQuantity" + "\n" +
                         "FROM dbo.Seller s" + "\n" +
                         "Join BYL.BuylistPurchaseShelvedInventory bpsi ON s.SellerId = bpsi.SellerId" + "\n" +
                         "GROUP BY s.DisplayName,s.SellerId" + "\n" +
                         "ORDER BY SUM (bpsi.Quantity) DESC";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }
        public void UpdateBuylistOffer(string buylistOfferNumber)
        {
            Console.WriteLine("Before Running Database: " + buylistOfferNumber);
            string updateQuery = "UPDATE BYL.BuylistOffer" + "\n" +
                         "SET ShelvedAt = GETDATE() - 31" + "\n" +
                         "WHERE OfferNumber = '" + buylistOfferNumber + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with Database is done!");
        }

        public void UpdateBuylistOfferQuantity()
        {
            string updateQuery = "Delete from byl.crp_cache" + "\n" +
                           "Insert into byl.crp_cache(sellerid, productconditionid, quantity, price, buyingpower, pendingquantity)" + "\n" +
                           "Select sellerid, productconditionid, quantity, price, buyingpower, pendingquantity" + "\n" +
                           "From byl.currentlyrequestedproducts";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with Database is done!");


        }
        public void UpdateBuylistPrice(string productName, string sellerName,string setName,string conditionName,string price)
        {
            string updateQuery = "Update BYL.BuyListProduct " +
                    "Set Price =  '" + price + "'" + "\n" +
                    "FROM [BYL].[BuyListProduct] BP, " +
                    "[PDT].[ProductCondition] PC," +
                    "[dbo].[Seller] SL," +
                    "[PDT].[Product] PR, " +
                    "[PDT].[SetName] ST, " +
                    "[PDT].[Condition] CT " +
                    "Where " +
                    "BP.sellerid=sl.sellerid and " +
                    "BP.ProductConditionId=PC.ProductConditionId and " +
                    "PR.SetNameId = ST.SetNameId and " +
                    "PC.productid=PR.productid and " +
                    "PC.conditionid=CT.conditionid and " +
                    "SL.DisplayName =" + "'" + sellerName + "'" + " and " +
                    "ProductName = " + "'" + productName + "'" + " and SetName = " + "'" + setName + "'" + "  and ConditionName = '" + conditionName + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with Database is done!");
            //StartBrowser.childTest.Info("Buylist updated price is " + 100.00);
        }

        public string SelectPriceQuery(string productName, string sellerName, string setName, string conditionName, string newPrice)
        {
            string selectQuery = " select price" +
                    "  FROM [BYL].[BuyListProduct] BP, " +
                    "[PDT].[ProductCondition] PC, " +
                    "[dbo].[Seller] SL, " +
                    "[PDT].[Product] PR, " +
                    "[PDT].[SetName] ST, " +
                    "[PDT].[Condition] CT " +
                    "where " +
                    "BP.sellerid=sl.sellerid and " +
                    "BP.ProductConditionId=PC.ProductConditionId and " +
                    "PR.SetNameId = ST.SetNameId and " +
                    "PC.productid=PR.productid and " +
                    "PC.conditionid=CT.conditionid and " +
                    "SL.DisplayName =" + "'" + sellerName + "'" + " and " +
                    " ProductName = " + "'" + productName + "'" + " and SetName = " + "'" + setName + "'" + "  and ConditionName = '" + conditionName + "'";
            Console.WriteLine(selectQuery);
            string price = DBSingleResultHelpers.DB_Method(selectQuery);
            Console.WriteLine(price);
            StartBrowser.childTest.Info("Buylist price is " + price);
            String actual_price = price;
            String expected_price = newPrice;
            Assert.That(actual_price, Is.EqualTo(expected_price));
            StartBrowser.childTest.Pass("Buylist price matched");
            return price;

        }

        public void UpdateBuylistLevelTo3(string userName)
        {
            string updateQuery = " UPDATE bp" + "\n" +
                          "SET PlayerLevelId = 3" + "\n" +
                          "FROM BYL.Player bp" + "\n" +
                          "Join dbo.[User] u ON bp.UserId = u.UserId" + "\n" +
                          "WHERE u.ProviderEmailAddress =  '" + userName + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with Database is done!");

        }

    }
}
