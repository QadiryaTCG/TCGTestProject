using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
    class PriceGuideQueries
    {
        public string[] GetProductLines()
        {
            string sql = "SELECT CategoryName" + "\n" +
                         "FROM PDT.Category";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
            Console.WriteLine("Database connection is done!");
        }

    }
}
