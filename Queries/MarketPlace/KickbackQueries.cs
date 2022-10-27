using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
   public class KickbackQueries
    {

        public string SelectKickbackId()
        {
            string selectQuery1 = "select KickbackId FROM KBK.Kickback WHERE Name = 'Download Report'";

            string KickbackId = DBSingleResultHelpers.DB_Method(selectQuery1);
            Console.WriteLine(KickbackId);
            return KickbackId;

        }
        // delete the kickback from 3 different table 
        public void DeleteKickbackfromAssociatedProductType(string kickbackId)
        {
            string updateQuery = "DELETE FROM [KBK].[AssociatedProductType] WHERE KIckbackID ='" + kickbackId + "'";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            
        }

        public void DeleteKickbackfromAssociatedProductLine(string kickbackId)
        {
            string updateQuery = "DELETE FROM [KBK].[AssociatedProductLine] WHERE KIckbackID ='" + kickbackId + "'";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
           
        }

        public void DeleteKickbackfromKickback(string kickbackId)
        {
            string updateQuery = "DELETE FROM KBK.Kickback  WHERE KIckbackID ='" + kickbackId + "'";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
           
        }
    }
}
