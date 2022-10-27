using Framework.Helpers;
using System;

namespace TCGplayerUI.Queries.MarketPlace
{
  public  class UpdateAddress
    {
        public void Updateaddressquery()
        {
            string updateQuery = "update[TCGStoreQA].[dbo].[AddressBook]  set FirstName = 'Test', LastName = 'Test', Address1 = '44 Eaglewood Cir',Phone = '5857305114' where UserId = 1516452";
            
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with database is done");
        }


    }
}
