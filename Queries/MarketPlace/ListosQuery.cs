using Framework.Helpers;
using System;

namespace TCGplayerUI.Queries.MarketPlace
{
   public class ListosQuery
    {
        // Update the Listos Inventory for Marketplace
        public void UpdateListosInventory(string StorePriceCustomId)
        {
            string updateQuery = "update dbo.StorePriceCustom set Quantity = 1000 where StorePriceCustomId = '" + StorePriceCustomId + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with database is done");

        }



    }
}
