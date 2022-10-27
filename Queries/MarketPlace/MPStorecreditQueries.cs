using Framework.Base;
using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
    
   public class MPStorecreditQueries 
    {
       
        public string SelectStoreCredit(string username)
        {
            string selectQuery = "Select  CAST(ISNULL(SUM(Amt),'0.00') AS DECIMAL(8,2)) AS 'StoreCreditAmount'" +
                                " FROM StoreCreditQueue scq " +
                                 "RIGHT JOIN[user] u ON u.userid = scq.UserId " +
                               " WHERE u.providerusername = '" + username + "'" +
                                "GROUP BY u.userid";
            Console.WriteLine(selectQuery);
            string StoreCreditAmount = DBSingleResultHelpers.DB_Method(selectQuery);
            StartBrowser.childTest.Info(StoreCreditAmount);
            return StoreCreditAmount;
        }

        // Insert Store Credit 
        public void InsertStoreCredit(string userid)
        {
            string updateQuery = "INSERT INTO StoreCreditQueue VALUES('" + userid + "', '5.00', 'Test automation', '" + userid + "', GetUTCDate(), NULL, NULL, NULL, 2)";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine(updateQuery);
            StartBrowser.childTest.Info("Store Credit is $5.00");
            

        }

        public void SetMPStoreCreditBalanceToZero(string userid)
        {
            string updateQuery = "DELETE FROM storecreditqueue WHERE userid = '" + userid + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine(updateQuery);
            StartBrowser.childTest.Info("Store Credit is Zero");

        }
    }
}

