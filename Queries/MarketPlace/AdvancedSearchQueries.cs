using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
    class AdvancedSearchQueries
    { 

       public string[] GetSetNames(string categoryName)
        {
            string sql = "SELECT SetName" + "\n" +
                         "FROM PDT.SetName s" + "\n" +
                         "join pdt.Category c On s.CategoryId=c.CategoryId" + "\n" +
                         "where c.CategoryName= '" + categoryName + "' and Active = 1";
            string[] value=DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
            Console.WriteLine("Database connection is done!");
        }

        public string[] GetFormats()
        {
            string sql = "SELECT FormatName" + "\n" +
                         "FROM DECK.Format";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
            Console.WriteLine("Database connection is done!");
        }

        public string[] GetRarity(string categoryName)
        {
            string sql = "SELECT DisplayText" + "\n" +
                         "FROM PDT.Rarity r" + "\n" +
                         "join pdt.Category c On r.CategoryId=c.CategoryId" + "\n" +
                         "where c.CategoryName= '" + categoryName + "'";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
            Console.WriteLine("Database connection is done!");
        }

        public string[] GetMagicCardType()
        {
            string sql = "SELECT Description" + "\n" +
                         "FROM PDT.MagicCardType" + "\n" +
                         " where MagiCcardTypeIndicatorId=1";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
            Console.WriteLine("Database connection is done!");
        }
    }

}
