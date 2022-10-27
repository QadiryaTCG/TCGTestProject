using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries
{
    class PackageTypeTiersQueries
    {
        public void CleanUpPackageTypeTiers()
        {
            string updateQuery = " update [SHP].[PackageType] set IsActive = 0 where Description = 'For automation testing purpose.' and IsActive = 1" + "\n" +
                          "update [SHP].[PackageTypeTier] set IsActive = 0 where PackageTypeTierId > 65 and IsActive = 1";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("CleanUp Package Type Tiers from Database is done!");

        }
    }
}
