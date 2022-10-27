using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    class MassPriceQueries
    {

        public string RuleId(string sellerKey)
        {
            string sql = "SELECT top 1 RuleId from PriceRuler.dbo.[Rule] Where SellerId = '" + sellerKey + "' order by RuleId desc";
            string ruleId = DBSingleResultHelpers.DB_Method(sql);
            return ruleId;
        }

        public string RuleRunHistoryId(string sellerKey)
        {
            string sql = "SELECT top 1 RuleRunHistoryId from PriceRuler.dbo.RuleRunHistory rrh Inner Join PriceRuler.dbo.[Rule] r On r.RuleId = rrh.RuleId Where SellerId = '" + sellerKey + "' order by r.RuleId desc";
            string RuleRunHistoryId = DBSingleResultHelpers.DB_Method(sql);
            return RuleRunHistoryId;
        }

        public string GetUniqueRuleName()
        {
            string sql = "declare @Existingdate datetime Set @Existingdate = GETDATE()  Select CONVERT(varchar, @Existingdate,13) as [DD MMM YYYY HH:MM:SS:MMM]";
            //string sql = "select replace(replace (getutcdate (), ' ', ''), ':', '')";
            string uniqueRuleName = DBSingleResultHelpers.DB_Method(sql);
            return uniqueRuleName;
        }
    }

}
