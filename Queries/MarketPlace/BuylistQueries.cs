using Framework.Base;
using Framework.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
   public class BuylistQueries
    {

       public void UpdateBuylistVerification(string usertitle)
        {
            string updateQuery = "update BYL.Player  set IsVerified = 1, IsLocked = 0" + 
                " where UserId in (SELECT [UserId]  FROM [dbo].[User]  where ProviderUserName = '" + usertitle + "')";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with database is done");

        }

        // This query updates the Buylist Offer Status to Completed
        public void UpdateBuylistOfferStatus(string buylistnumber)
        {
            Console.WriteLine(buylistnumber);
            string updateQuery = "Update bo" + "\n" +
				"Set BuyListOfferStatusId ='11' " + "\n" +
				"From BYL.BuylistOffer bo" + "\n" +
				"Where OfferNumber = '"+buylistnumber+"'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with database is done");

        }

		public string SelectPriceQuery(string productName, string sellerName)
		{
			string selectQuery = " select price" +
					"FROM [BYL].[BuyListProduct] BP, " +
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
					" ProductName = " + "'" + productName + "'" + " and SetName = '8th Edition'  and ConditionName = 'Near Mint'";
			Console.WriteLine(selectQuery);
			string price = DBSingleResultHelpers.DB_Method(selectQuery);
			Console.WriteLine(price);
			StartBrowser.childTest.Info("Buylist price is " + price);
			String actual_price = price;
			String expected_price = "50.00";
			Assert.That(actual_price, Is.EqualTo(expected_price));
			StartBrowser.childTest.Pass("Buylist price matched");
			return price;

        }

		public void UpdateBuylistPrice(string productName, string sellerName)
		{
			string updateQuery = " update BYL.BuyListProduct " +
					"  set Price = 100.00 " +
					"  FROM [BYL].[BuyListProduct] BP, " +
					"[PDT].[ProductCondition] PC," +
					"[dbo].[Seller] SL," +
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
					" ProductName = " + "'" + productName + "'" + " and SetName = '8th Edition'  and ConditionName = 'Near Mint'";
			Console.WriteLine(updateQuery);
			DBUpdateHelpers.DBUpdateMethod(updateQuery);
			StartBrowser.childTest.Info("Buylist updated price is " + 100.00);
		}

		public void ResetBuylistOriginalPrice(string productName, string sellerName)
		{
			string updateQuery = " update BYL.BuyListProduct " +
					"  set Price = 50.00 " +
					"  FROM [BYL].[BuyListProduct] BP, " +
					"[PDT].[ProductCondition] PC," +
					"[dbo].[Seller] SL," +
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
					" ProductName = " + "'" + productName + "'" + " and SetName = '8th Edition'  and ConditionName = 'Near Mint'";
			Console.WriteLine(updateQuery);
			DBUpdateHelpers.DBUpdateMethod(updateQuery);
			StartBrowser.childTest.Info("Reset Buylist price is " + 50.00);
		}
	}
}


