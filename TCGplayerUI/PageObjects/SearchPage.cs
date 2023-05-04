using AventStack.ExtentReports;
using Framework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects.MarketPlace
{
    public class SearchPage : StartBrowser
    {
        private ActionMethods _actionMethods;
        SearchPage searchpage;
        NewPDPage pdpage;
        public SearchPage(ThreadLocal<IWebDriver> driver)
        {
            SearchPage.driver = driver;
            _actionMethods = new ActionMethods();
        }

        //After searching seller verify Shopping From display on search page
        By Shoppingfrom = By.XPath("//div[@class='shop-by-seller-title']");
        public void IsShoppingfromExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Shoppingfrom, "Shopping From", 30);
        }

        //Leave button display
        By btnLeavebtn = By.XPath("//button[@data-testid='btnLeaveSeller']");
        public void IsLeavebtnExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(btnLeavebtn, "Leave", 30);
        }
        //Grid View search results
        By gridSearchResults = By.XPath("//section[@class='search-results']");
        public void IsgridSearchResultsExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(gridSearchResults, "Grid Search results", 200);
        }

        //Click on Leave Storefront
        By LeaveStorefront = By.XPath("//button[@data-testid='removeSellerFilter']");
        public void ClickOnLeaveStrorefront()
        {
            _actionMethods.ClickWithWait(LeaveStorefront, "Leave Storefront", 30);
        }
        //After clicking Leave Storefront verify Find A Seller display
        By FindaSellerdisplay = By.XPath("//span[@class='tcg-standard-button__content'][text()=' Find A Seller ']");
        public void IsFindaSellerExist()
        {
            _actionMethods.AssertElementIsDisplayed(FindaSellerdisplay, "Find A Seller");
        }

        //Change the toggle from Grid to List View
        By ToggleView = By.XPath("//button[@data-testid='list-view-btn']");
        public void ClickOnToggle()
        {
            _actionMethods.ClickWithWait(ToggleView, "List View", 30);
        }

        //Direct filter display
        By Directfilter = By.XPath("//span[@data-testid='direct-seller']");
        public void IsDirectFilterExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Directfilter, "Direct by TCGplayer", 40);
        }

        //Click on Direct filter
        By SelectDirectfilter = By.XPath("//span[@data-testid='direct-seller']");
        public void ClickOnDirectFilter()
        {
            _actionMethods.ClickWithWait(SelectDirectfilter, "Direct by TCGplayer", 30);
        }

        //After clicking on Direct filter verify Direct display for listings
        By Directlisting = By.XPath("descendant::div[@class='listing-spotlight'][1]");
        public void IsDirectlistingExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Directlisting, "Direct by TCGplayer", 50);
        }

        //After unchacking Direct filter verify direct listing icon not display
        By nonDirectlistings = By.XPath("descendant::section[@data-testid='listing-item--0'][1]");
        public void IsnonDirectlistingsExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(nonDirectlistings, "Non Direct listings", 30);
        }

        //Click on Verified Sellers filter
        By VerifiedSeller = By.XPath("//span[@data-testid='verified-seller']");
        public void ClickOnVerifiedSeller()
        {
            _actionMethods.Click(VerifiedSeller, "Verified Sellers");
        }

        //Click on Sellers In Cart filter
        By SellerInCartFilter = By.XPath("//span[@data-testid='cart-seller']");
        public void ClickOnSellersInCart()
        {
            _actionMethods.ClickWithWait(SellerInCartFilter, "Sellers In Cart", 30);
        }

        //List View search results display
        By ListViewresults = By.XPath("//section[@class='search-results is-list']");
        public void IsListViewsearchresultsExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(ListViewresults, "Listview search results", 100);
        }

        //Sort Products by display
        By SortProductBy = By.XPath("//label[(text()='Sort By:')]");
        public void IsSortProductsByExist()
        {
            _actionMethods.AssertElementIsDisplayed(SortProductBy, "Sort Products By");
        }

        //  default Relevance option display 
        By bestMatch = By.XPath("//div[@class='tcg-input-select__trigger-container']//span[text()='Best Match']");
        public void IsBestMatchExist()
        {
            _actionMethods.AssertElementIsDisplayed(bestMatch, "Best Match");
        }


        By valueBestSelling = By.XPath("//li[@aria-label='Best Selling']");
        public void SelectBestSelling()
        {
            _actionMethods.Click(valueBestSelling, "Best Selling");
        }
        By Pagination = By.XPath("//span[@class='tcg-standard-button__icon']");

        public void IsPaginationExist()
        {
            _actionMethods.AssertElementIsDisplayed(Pagination, "Pagination Arrow");
        }
        //Click on page 2 
        By Page2 = By.XPath("//span[@class='tcg-standard-button__content'][text()='2']");
        public void ClickOnPage2()
        {
            _actionMethods.Click(Page2, " Page 2");
        }

        By firstListing = By.XPath("descendant::div[@class='search-result'][1]");
        public void OpenANewTab()
        {
            _actionMethods.OpenNewTab(firstListing);
        }

        //Find A Seller: Click on Find A Seller
        By btnFindASeller = By.XPath("//span[@class='tcg-standard-button__content'][text()=' Find A Seller ']");
        public void ClickOnFindaSeller()
        {
            _actionMethods.ClickWithWait(btnFindASeller, "Find A Seller", 30);
        }
    }
    }

