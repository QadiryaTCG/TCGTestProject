using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    public class MessageQueries : StartBrowser
    {
		//Get count of unread messages for a user
		//info obtained from: https://github.com/TCGplayer/dominaria/blob/develop/src/Database/TcgStore/VCS/Stored%20Procedures/VCS.GetEntityUnreadMessagesCountInContext.sql
		public string GetUnreadMessageCount(string providerUserName, string sellerId)
        {
			string sql = "declare" + "\n" +
			"@EntityId BIGINT = (select UserId from dbo.[User] where ProviderUserName = '" + providerUserName + "')," + "\n" +
			"@EntityIndId INT = 3," + "\n" +
			"@SellerId BIGINT = " + sellerId + "\n" +
			"select count(*)   from VCS.Thread t" + "\n" +
			"Inner Join VCS.[Message] m ON m.ThreadID = t.Threadid" + "\n" +
			"INNER JOIN[dbo].[SellerOrder] so ON so.ThreadContainerId = t.ThreadContainerId AND so.SellerId = @SellerId" + "\n" +
			"INNER JOIN[dbo].[Order] o ON o.OrderId = so.OrderId" + "\n" +
			"Where m.IsTcgRead = 0" + "\n" +
			"AND NOT" + "\n" +
				"(" + "\n" +
					"m.CreatedByEntityId = @EntityId" + "\n" +
					"AND m.CreatedByEntityIndId = @EntityIndId" + "\n" +
				")" + "\n" +
				"AND" + "\n" +
					"(" + "\n" +
						"(" + "\n" +
							"t.ReceiverEntityId = @EntityId" + "\n" +
							"AND t.ReceiverEntityIndId = @EntityIndId" + "\n" +
							"AND t.IsReceiverTrashed = 0" + "\n" +
							"AND m.IsVisibleToReceiver = 1" + "\n" +
							"AND t.SenderEntityId = @SellerId" + "\n" +
							"AND o.ChannelId = 1" + "\n" +
						")" + "\n" +
						"OR" + "\n" +
						"(" + "\n" +
							"t.SenderEntityId = @EntityId" + "\n" +
							"AND t.SenderEntityIndId = @EntityIndId" + "\n" +
							"AND t.IsSenderTrashed = 0" + "\n" +
							"AND m.IsVisibleToSender = 1" + "\n" +
							"AND t.ReceiverEntityId = @SellerId" + "\n" +
							"AND o.ChannelId = 1" + "\n" +
						")" + "\n" +
					")";
			string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        


    }
}