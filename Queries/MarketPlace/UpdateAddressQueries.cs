using Framework.Helpers;
using System;

namespace TCGplayerUI.Queries.MarketPlace
{
    public class UpdateAddressQueries
    {
        public void Updateaddressquery()
        {
            string updateQuery = "update [dbo].[AddressBook]  set FirstName = 'Test', LastName = 'Test', Address1 = '44 Eaglewood Cir',Phone = '5857305114' where UserId = 1516452";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with database is done");
        }
        public void AddAddress(string userName)
        {
            string updateQuery = "update dbo.AddressBook" + "\n" +
                                 "set FirstName = 'Test', LastName = 'Test'," + "\n" +
                                  "Address1 = '44 Eaglewood Cir', Phone = '5857305114'" + "\n" +
                                  "from dbo.AddressBook ab" + "\n" +
                                   "Right Join [User] u" + "\n" +
                                   "on AB.userId = u.UserId" + "\n" +
                                    "where u.ProviderEmailAddress ='" + userName + "'";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Connection with database is done");
        }


    }
}
