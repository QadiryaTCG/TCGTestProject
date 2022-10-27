using Framework.Base;
using Framework.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.Queries.CSI
{
  public  class SubscriptionQueries
    {
        private ActionMethods _actionMethods;


        // Following query compares the SubStatus Zero for cancelled subscription user
        public string SelectUserSubscriberCancelled(string userid)
          {
            _actionMethods = new ActionMethods();

            string selectQuery = "Select SubStatus FROM dbo.UserSubscriber WHERE UserId = '" + userid + "'";                   
            string SubStatus = DBSingleResultHelpers.DB_Method(selectQuery);
           string expectedSubStatus = "0";
            _actionMethods.AssertTwoStringsAreEqual(expectedSubStatus, SubStatus);

            StartBrowser.childTest.Info(SubStatus);
            return SubStatus;
            
        }

        // Following query compares the SubStatus 1 for active subscription user
        public string SelectUserSubscriberActive(string userid)
        {
            _actionMethods = new ActionMethods();

            string selectQuery = "Select SubStatus FROM dbo.UserSubscriber WHERE UserId = '" + userid + "'";
            string SubStatus = DBSingleResultHelpers.DB_Method(selectQuery);
            string expectedSubStatus = "1";
            _actionMethods.AssertTwoStringsAreEqual(expectedSubStatus, SubStatus);

            StartBrowser.childTest.Info(SubStatus);
            return SubStatus;

        }

        // Following query compares cancelled status for subscriber cancelled subscription in CSI Subscription table
        public string SelectCSISubscriptionCancelled(string userid)
        {
            _actionMethods = new ActionMethods();
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");

            string selectQuery = "Select data FROM csidb_" + envData["envLowerCSI"] + ".csi.Subscription WHERE UserId = '" + userid + "'";
            Console.WriteLine(selectQuery);
            string SubStatus = DBSingleResultHelpers.DB_Method(selectQuery);
         
            _actionMethods.AssertAStringContainsAValue(SubStatus, "cancelled");
           
            return SubStatus;

        }

        //  Following query compares Active status for subscriber Active subscription in CSI Subscription table
        public string SelectCSISubscriptionActive(string userid)
        {
            _actionMethods = new ActionMethods();
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");

            string selectQuery = "Select data FROM csidb_" + envData["envLowerCSI"] + ".csi.Subscription WHERE UserId = '" + userid + "'";
            string SubStatus = DBSingleResultHelpers.DB_Method(selectQuery);

            _actionMethods.AssertAStringContainsAValue(SubStatus, "active");

            return SubStatus;

        }

        // Following query update the Substatus to active
        public void UpdateSubStatus(string Email)
        {
            string updateQuery = "update [dbo].[UserSubscriber]  set SubStatus = 1 where UserId = '" + Email + "'";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with database is done");
        }
        // Need to work on this query later on 
       //// Following query update the data for CSI Subscription
       //public void UpdateData(string userid)
       // {
       //     var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");


       //     string updateQuery = string.Format("update [csidb_qa].[csi].[Subscription] set data = '{"id":162,"activated":"2021-07-13T02:25:35Z","active":true,"braintreeID":"6yrg9m","created":"2021-07-12T18:36:16Z","productCode":"TCGplayer Infinite","status":"active","updated":"2021-07-13T02:25:35Z","userID":1516767,"data":{"billingPeriod":1,"billingRenewal":"2021-08-12T18:36:16Z", "kickback":1,"kickbackPriceThreshold":35,"daysTilRenewal":30,"daysToNextTier":0,"subDuration":"new","subLength":0}} 'where UserId = 1516767 ");

       //     DBUpdateHelpers.DBUpdateMethod(updateQuery);
       //     Console.WriteLine(updateQuery);

      // }

        // Following query verifes the subscription status for Sign Up subscription 
        public string SelectSubscriptionStatus(string email)
        {
            _actionMethods = new ActionMethods();

            string selectQuery1 = "Select UserId FROM dbo.[User] WHERE providerusername = '" + email + "'";
            string UserId = DBSingleResultHelpers.DB_Method(selectQuery1);

            string selectQuery2 = "Select SubStatus FROM dbo.UserSubscriber WHERE UserId = '" + UserId + "'";
            string SubStatus = DBSingleResultHelpers.DB_Method(selectQuery2);
            string expectedSubStatus = "1";
            _actionMethods.AssertTwoStringsAreEqual(expectedSubStatus, SubStatus);

            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");

            string selectQuery = "Select Count(*) FROM csidb_" + envData["envLowerCSI"] + ".csi.Subscription WHERE UserId = '" + UserId + "'";
            string actualrownumber = DBSingleResultHelpers.DB_Method(selectQuery);
            string expectedrownumber = "1";
            _actionMethods.AssertTwoStringsAreEqual(expectedrownumber, actualrownumber);

            StartBrowser.childTest.Info(SubStatus);
            return SubStatus;
           
        }

     
    }
}
