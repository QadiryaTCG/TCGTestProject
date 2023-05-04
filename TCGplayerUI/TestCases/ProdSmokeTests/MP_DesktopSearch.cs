using Framework.Base;
using NUnit.Framework;
using System;
using System.Threading;
using TCGplayerUI.BusinessMethods.MarketPlace;
using TCGplayerUI.PageObjects.MarketPlace;

namespace TCGplayerUI.TestCases.MarketPlace.ProdSmokeTests
{
    public class MP_DesktopSearchProd : StartBrowser
    {
        public MP_DesktopSearchProd() : base(SetUpClass.extent) { }
        SearchPage searchpage;
        FindASeller findaseller;
        NewPDPage pdpage;
        SearchTermMethod searchtermmethod;
        NotaPage notapage;
        public MP_DesktopSearchProd(string profile, string environment) : base(profile, environment, SetUpClass.extent) { }

        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void FindASeller()
        {
           
                Setup(SetUpClass.extent, "searchUrl");
                searchpage = new SearchPage(driver);
                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Test Find A Seller functionality");
                Thread.Sleep(3000);
                //reusable method for Find A Seller
                findaseller = new FindASeller();
                findaseller.MPFindSeller();
                Thread.Sleep(4000);
                searchpage.IsShoppingfromExist();
                searchpage.IsLeavebtnExist();
                searchpage.IsgridSearchResultsExist();
                searchpage.ClickOnLeaveStrorefront();
                Thread.Sleep(4000);
                searchpage.IsFindaSellerExist();

        }

        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void SellerFilters()
        {
            
                Setup(SetUpClass.extent, "searchUrl");
                searchpage = new SearchPage(driver);
                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Test Seller Filters functionality");
                Thread.Sleep(3000);
                searchpage.ClickOnToggle();
                Thread.Sleep(3000);
                searchpage.IsDirectFilterExist();
                searchpage.ClickOnDirectFilter();
                Thread.Sleep(4000);
                searchpage.IsDirectlistingExist();
                searchpage.ClickOnDirectFilter();
                Thread.Sleep(3000);
                searchpage.IsnonDirectlistingsExist();
                Thread.Sleep(3000);
                searchpage.ClickOnVerifiedSeller();
                Thread.Sleep(3000);
                searchpage.IsnonDirectlistingsExist();
                searchpage.ClickOnVerifiedSeller();
                Thread.Sleep(3000);
                searchpage.ClickOnSellersInCart();
                Thread.Sleep(4000);
                searchpage.IsListViewsearchresultsExist();
            
        }

        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void SortProductsBy()
        {

            Setup(SetUpClass.extent, "searchUrl");
            searchpage = new SearchPage(driver);
            StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Test Sort Products By functionality");
            Thread.Sleep(3000);
            searchpage.ClickOnToggle();
            Thread.Sleep(3000);
            searchpage.IsSortProductsByExist();
            searchpage.IsBestMatchExist();
            Thread.Sleep(3000);
            searchpage.SelectBestSelling();
            Thread.Sleep(4000);
            searchpage.IsListViewsearchresultsExist();

        }

        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void Pagination()
        {
           
                Setup(SetUpClass.extent, "searchUrl");
                searchpage = new SearchPage(driver);
                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Test pagination functionality");

                // driver.Navigate().GoToUrl("https://www.tcgplayer.com/search/all/product");
                Thread.Sleep(3000);
                searchpage.IsPaginationExist();
                searchpage.ClickOnPage2();
                Thread.Sleep(3000);

                String URL = driver.Value.Url; Assert.AreEqual(URL, "https://www.tcgplayer.com/search/all/product?view=grid&page=2");
           
        }


        // This test will verify the Right click and open a new tab functionality for Grid View
        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void OpenANewTabOnGridView()
        {
             Setup(SetUpClass.extent, "baseUrl");
                searchpage = new SearchPage(driver);
                pdpage = new NewPDPage(driver);
                searchtermmethod = new SearchTermMethod();

                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Verify Right click and open a new tab functionality");
                Thread.Sleep(3000);
                //Search term coming from Business methods
                searchtermmethod.ProdSearchtermTest();
                // On Grid View
                // Right click on card click on Open in New Tab
                searchpage.OpenANewTab();
                // After right click the new tab should open and change the window focus and verify PD page spotlight
                driver.Value.SwitchTo().Window(driver.Value.WindowHandles[1]);
                Thread.Sleep(3000);
                pdpage.IsSpotlightExist();
                Thread.Sleep(3000);
           
        }

        // This test will verify if user don't land on real page , user should see 404 page 
        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void ErrorPageTest()
        {
            
                Setup(SetUpClass.extent, "404PageUrl");
                notapage = new NotaPage(driver);

                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Verify 404 page display");
                Thread.Sleep(3000);

                notapage.Is404ImageExist();
                notapage.IsSorryMessageExist();
                notapage.ClickOnTCGHomePage();

           
        }


        
    }
}
