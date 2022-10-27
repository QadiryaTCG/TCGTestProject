using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries.MarketPlace
{
   public class GiftCardQueries
    {
        // Following query will get the redeem code for gift card
        public string SelectCode(string email)
        {
            string selectQuery = "Select Code from GC.GiftCard Where ToEmail = '" + email + "'";
            string Code = DBSingleResultHelpers.DB_Method(selectQuery);
            Console.WriteLine(Code);
            return Code;

        }

        // Following query will get the StoreCreditQueueId
        public string SelectStoreCreditQueueId(string userid)
        {
            string selectQuery = "Select StoreCreditQueueId from dbo.StoreCreditQueue where userid = '" + userid + "'";
            string StoreCreditQueueId = DBSingleResultHelpers.DB_Method(selectQuery);
            Console.WriteLine(StoreCreditQueueId);
            return StoreCreditQueueId;

        }

        public string SelectGiftCardId(string StoreCreditQueueId)
        {
            string selectQuery1 = "select GiftCardId from GC.GiftCard where StoreCreditQueueId in ('" + StoreCreditQueueId + "')";
            string GiftCardId = DBSingleResultHelpers.DB_Method(selectQuery1);
            Console.WriteLine(GiftCardId);
            return GiftCardId;

        }

        public void DeleteCode(string giftcardcode)
        {
            string updateQuery = "Delete from GC.GiftCard where Code = '" + giftcardcode + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine(updateQuery);
        }

        public void DeleteCode1(string userName)
        {
            string updateQuery = "Delete from GC.GiftCard where Code in (SELECT Code FROM GC.GiftCard where ToEmail = '" + userName + "')";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine(updateQuery);
        }

        public void DeleteStoreCreditForGiftCard(string userid)
        {
            string updateQuery = "Delete from dbo.StoreCreditQueue where UserId = '" + userid + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine(updateQuery);
        }

        // Select query to get StoreCreditQueueStatusId 
        public string SelectStoreCreditQueueStatusId(string userid)
        {
            string selectQuery = "Select StoreCreditQueueId from dbo.StoreCreditQueue where userid = '" + userid + "' and StoreCreditQueueStatusId = 1 ";
            string StoreCreditQueueId = DBSingleResultHelpers.DB_Method(selectQuery);
            Console.WriteLine(selectQuery);
            Console.WriteLine(StoreCreditQueueId);
            return StoreCreditQueueId;

        }

        // Update query to update the StoreCreditQueueStatusId to 2 to approve the store credit more than $100
        public void UpdateStoreCreditQueueStatusId(string StoreCreditQueueId)
        {
            string updateQuery = "update dbo.StoreCreditQueue set StoreCreditQueueStatusId = 2 where StoreCreditQueueId = '" + StoreCreditQueueId + "'";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine(updateQuery);

        }
    }
}
