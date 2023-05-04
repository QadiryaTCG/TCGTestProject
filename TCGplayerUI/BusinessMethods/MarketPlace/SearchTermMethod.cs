using Framework.Base;
using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TCGplayerUI.PageObjects.MarketPlace;

namespace TCGplayerUI.BusinessMethods.MarketPlace
{
    public class SearchTermMethod : StartBrowser
    {
        HomePage homepage;
        SearchPage searchpage;
        public void SearchtermTest()
        {
            homepage = new HomePage(driver);
            searchpage = new SearchPage(driver);

            var searchData = JsonHelpers.GetJsonData("MarketPlace" + Path.DirectorySeparatorChar + "QATestData.json");
            string SearchData = searchData["searchTerm"];
            homepage.AssertSearchBarDisplayed();
            homepage.SearchAutocomplete(SearchData);
            homepage.ClickOnSpyBtn();
            searchpage.IsgridSearchResultsExist();
        }

        // Comic Search term method
        public void ComicSearchTerm()
        {
            homepage = new HomePage(driver);
            searchpage = new SearchPage(driver);

            var searchData = JsonHelpers.GetJsonDataEnv("MP" + Path.DirectorySeparatorChar + "MPTestData.json");
            string SearchData = searchData["comicProductName"];
            homepage.AssertSearchBarDisplayed();
            homepage.SearchAutocomplete(SearchData);
            Thread.Sleep(2000);
            homepage.ClickOnSpyBtn();

        }

        public void SearchtermListViewTest()
        {
            homepage = new HomePage(driver);
            searchpage = new SearchPage(driver);

            var searchData = JsonHelpers.GetJsonData("MarketPlace" + Path.DirectorySeparatorChar + "QATestData.json");
            string SearchData = searchData["searchTerm"];
            homepage.AssertSearchBarDisplayed();
            homepage.SearchAutocomplete(SearchData);
            homepage.ClickOnSpyBtn();
            Thread.Sleep(4000);
            searchpage.IsListViewsearchresultsExist();
        }

        public void SearchGiftCardOnGridView()
        {
            homepage = new HomePage(driver);
            searchpage = new SearchPage(driver);

            var searchData = JsonHelpers.GetJsonData("MarketPlace" + Path.DirectorySeparatorChar + "QATestData.json");
            string SearchData = searchData["searchGiftCard"];
            homepage.AssertSearchBarDisplayed();
            homepage.SearchAutocomplete(SearchData);
            homepage.ClickOnSpyBtn();
            Thread.Sleep(6000);
            searchpage.IsgridSearchResultsExist();
        }

        public void SearchGiftCardOnListView()
        {
            homepage = new HomePage(driver);
            searchpage = new SearchPage(driver);

            var searchData = JsonHelpers.GetJsonData("MarketPlace" + Path.DirectorySeparatorChar + "QATestData.json");
            string SearchData = searchData["searchGiftCard"];
            homepage.AssertSearchBarDisplayed();
            homepage.SearchAutocomplete(SearchData);
            homepage.ClickOnSpyBtn();
            Thread.Sleep(4000);
            searchpage.ClickOnToggle();
        }


        public void ProdSearchtermTest()
        {
            homepage = new HomePage(driver);
            searchpage = new SearchPage(driver);

            var searchData = JsonHelpers.GetJsonData("MarketPlace" + Path.DirectorySeparatorChar + "ProdTestData.json");
            string SearchData = searchData["searchTerm"];
            homepage.AssertSearchBarDisplayed();
            homepage.SearchAutocomplete(SearchData);
            Thread.Sleep(5000);
            homepage.ClosePopUp();
            Thread.Sleep(3000);
            homepage.ClickOnSpyBtn();
            searchpage.IsgridSearchResultsExist();
        }

        public void GenericSearchtermTest(string searchTerm)
        {
            homepage = new HomePage(driver);
            searchpage = new SearchPage(driver);

            homepage.AssertSearchBarDisplayed();
            homepage.SearchAutocomplete(searchTerm);
            homepage.ClickOnSpyBtn();
            searchpage.IsgridSearchResultsExist();
        }
    }
}