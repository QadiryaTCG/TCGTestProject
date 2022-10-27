using Framework.Base;
using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries
{
    class DirectInventoryQueries : StartBrowser
    {
        public string GetProductName(string productConditionId)
        {
            string sql = "SELECT p.ProductName" + "\n" +
                         "FROM PDT.Product p" + "\n" +
                         "Join PDT.SetName sn ON p.SetNameId = sn.SetNameId" + "\n" +
                         "Join PDT.ProductCondition pc ON p.ProductId = pc.ProductId" + "\n" +
                         "Join PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
                         "WHERE pc.ProductConditionId in (" + productConditionId + ")";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        public string GetSetName(string productConditionId)
        {
            string sql = "SELECT sn.SetName" + "\n" +
                         "FROM PDT.Product p" + "\n" +
                         "Join PDT.SetName sn ON p.SetNameId = sn.SetNameId" + "\n" +
                         "Join PDT.ProductCondition pc ON p.ProductId = pc.ProductId" + "\n" +
                         "Join PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
                         "WHERE pc.ProductConditionId in (" + productConditionId + ")";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        public string GetConditionName(string productConditionId)
        {
            string sql = "SELECT c.ConditionName" + "\n" +
                         "FROM PDT.Product p" + "\n" +
                         "Join PDT.SetName sn ON p.SetNameId = sn.SetNameId" + "\n" +
                         "Join PDT.ProductCondition pc ON p.ProductId = pc.ProductId" + "\n" +
                         "Join PDT.Condition c ON pc.ConditionId = c.ConditionId" + "\n" +
                         "WHERE pc.ProductConditionId in (" + productConditionId + ")";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        public string GetProductAvailableQuantity(string productConditionId)
        {
            string sql = "SELECT QtyAvailable FROM TCGD.DirectInventory" + "\n" +
                         "WHERE ProductConditionId in (" + productConditionId + ")";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Update Direct inventory for a product
        public void UpdateDirectInventory(string quantity, string productConditionId)
        {
            string updateQuery = "update TCGD.DirectInventory set QtyAvailable = " + quantity + " where DirectInventoryId in (select DirectInventoryId from TCGD.DirectInventory di where ProductConditionId = " + productConditionId + ")";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

    }
}
