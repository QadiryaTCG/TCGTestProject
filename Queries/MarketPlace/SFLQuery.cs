using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{

    // Delete the SFL from Cart 
   public class SFLQuery
    {
        public void ClearSFLCart(string CreatedByUserId)
        {
            string updateQuery = "DELETE FROM [dbo].[SaveForLaterProduct] WHERE CreatedByUserId = '" + CreatedByUserId + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            
        }
        public void ClearSFLCartWithUserName(string userName)
        {
            string updateQuery = "DELETE FROM [dbo].[SaveForLaterProduct]"+ "\n"+
                                  "FROM[dbo].[SaveForLaterProduct] s" + "\n"+
                                   "JOIN [dbo].[User] u On s.CreatedByUserId = u.UserId" + "\n"+
                                    "WHERE u.ProviderUserName = '" + userName + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);

        }

    }
}
