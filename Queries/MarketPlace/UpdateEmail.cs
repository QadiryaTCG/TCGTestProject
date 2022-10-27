using Framework.Base;
using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
    public class UpdateEmail
    {
        public void UpdateEmail1(string oldemail, string newemail, string userid, string updatedbyuserid)
        {

            // string updateQuery = "exec dbo.UpdateUserEmail 'NewAutoEmail@gmail.com', 'ChangeemailText@gmail.com', 1516666, 609 ;";
            string updateQuery = "exec dbo.UpdateUserEmail '" + oldemail + "','" + newemail + "' , '" + userid + "', '" + updatedbyuserid + "' ;";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with database is done");
            Console.WriteLine(updateQuery);
            StartBrowser.childTest.Pass("Email Updated Successfully");

        }

    }
}
