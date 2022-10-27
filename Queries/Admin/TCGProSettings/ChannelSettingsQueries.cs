using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    class ChannelSettingsQueries
    {
        //Update the seller to Channel 0
        public void EnableChannel0(string sellerId)
        {
            string updateQuery = "UPDATE dbo.SellerProServicesSettings set dbo.SellerProServicesSettings.ChannelId = 0 where SellerId = " + sellerId;            
            DBUpdateHelpers.DBUpdateMethod(updateQuery);

        }

        //Update the seller to Channel 1
        public void EnableChannel1(string sellerId)
        {
            string updateQuery = "UPDATE dbo.SellerProServicesSettings set dbo.SellerProServicesSettings.ChannelId = 1 where SellerId = " + sellerId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);

        }


    }
}