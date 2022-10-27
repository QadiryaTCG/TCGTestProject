using Framework.Base;
using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries
{
    class FCSQueries : StartBrowser
    {
        public void ResetRI(string ReimOrderNumber)
        {

            string updateQuery = "DECLARE @ReimOrderId INT = (SELECT ReimOrderId FROM TCGD.ReimOrder WHERE ReimOrderNumber = '" + ReimOrderNumber + "')" + "\n" +
                             "DELETE FROM TCGD.ReimOrderTracking WHERE ReimOrderId = @ReimOrderId " + "\n" +
                             "DELETE FROM [ADT].[ReimOrderAuditTrail] WHERE ReimOrderId = @ReimOrderId" + "\n" +
                             "DELETE FROM [ADT].[ReimOrderAuditChange] WHERE ReimOrderAuditId in (SELECT ReimOrderAuditId FROM [ADT].[ReimOrderAudit] WHERE ReimOrderId = @ReimOrderId)" + "\n" +
                             "DELETE FROM [ADT].[ReimOrderAudit] WHERE ReimOrderId = @ReimOrderId" + "\n" +
                             "DELETE FROM TCGD.SellerExtraInventory WHERE ReimOrderProdDiscId in (Select ReimOrderProdDiscId FROM TCGD.ReimOrderProdDisc WHERE ReimOrderId = @ReimOrderId)" + "\n" +
                             "DELETE FROM [TCGD].[ReimOrderProdDisc] WHERE ReimOrderId = @ReimOrderId" + "\n" +
                             "UPDATE TCGD.ReimOrder SET ReimOrderStatusId = 1, CreatedAt = GETDATE(), ShelvedAt = Null, ShelvedByUserId = NULL, LockedByUserId = NULL, LockedAt = NULL, IsPaused = 0, ReceivingLevel = 0 WHERE ReimOrderId = @ReimOrderId";
           /* LogHelpers.CreateLogFile();
            LogHelpers.Write(updateQuery);*/
            DBUpdateHelpers.DBUpdateMethod(updateQuery);

        }








    }
}
