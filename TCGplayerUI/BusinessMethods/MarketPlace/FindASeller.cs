using Framework.Base;
using Framework.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TCGplayerUI.PageObjects.MarketPlace;

namespace TCGplayerUI.BusinessMethods.MarketPlace
{
   public class FindASeller : StartBrowser
    {
        SearchPage searchpage;
        SellersPage sellerspage;
  
        public void MPFindSeller()
        {
            searchpage = new SearchPage(driver);
            sellerspage = new SellersPage(driver);
            Thread.Sleep(3000);
            searchpage.ClickOnFindaSeller();
            Thread.Sleep(3000);
            sellerspage.IsSellerNamesearchExist();
            sellerspage.IsCheckboxesExist();

            var sellerData = JsonHelpers.GetJsonData("MarketPlace" + Path.DirectorySeparatorChar + "ProdTestData.json");
            string SellerData = sellerData["sellername"];
            sellerspage.EnterSellerName(SellerData);
            sellerspage.ClickOnSearch();
            Thread.Sleep(3000);
            sellerspage.ClickOnShopThisSeller();
        }


        

        
    }
}
