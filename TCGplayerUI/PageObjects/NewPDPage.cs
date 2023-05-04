using Framework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects.MarketPlace
{
    public class NewPDPage : StartBrowser
    {
        private ActionMethods _actionMethods;
        NewPDPage pdPage;
        SearchPage searchPage;

        public NewPDPage(ThreadLocal<IWebDriver> driver)
        {
            NewPDPage.driver = driver;
            _actionMethods = new ActionMethods();
            NewPDPage pdPage;
        }

        //Verify the title of the product
        By Producttitle = By.XPath("//h1[@data-testid='lblProductDetailsProductName']");
        public void ISProductTitleExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Producttitle, "Product Title", 30);
        }
        //Verify  Spotlight display
        By Spotlight = By.XPath("//section[@class='product-details__spotlight']");
        public void IsSpotlightExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Spotlight, "Spotlight", 40);
        }

        //Verify Direct spotlight banner
        By DirectSpotlightBanner = By.XPath("//h2[@class='spotlight__banner direct']");
        public void IsDirectspotlightBannerExist()
        {
            _actionMethods.AssertElementIsDisplayed(DirectSpotlightBanner, "Direct by TCGplayer");
        }
        //Verify Image display
        By Imagedisplay = By.XPath("//section[@data-testid='imgProductDetailsMain']");

        public void IsImageExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Imagedisplay, "Product Image", 20);
        }

        //Verify Product details display
        By ProductDetails = By.XPath("//div[@class='product-details__product']");
        public void IsProductdetailsExist()
        {
            _actionMethods.AssertElementIsDisplayed(ProductDetails, "Details");
        }

        //Verify Filters display
        By Filters = By.XPath("//div[@class='product-details__listings-filters']");
        public void IsFiltersExist()
        {
            _actionMethods.AssertElementIsDisplayed(Filters, "Filters");
        }
        //Verify Price Listings display
        By Pricelisting = By.XPath("descendant::section[14]");
        public void IsPricelistingsExist()
        {
            _actionMethods.AssertElementIsDisplayed(Pricelisting, "Price Listings");
        }


        //Verify listings toolbar display including Sort By and Listings Per Page
        By Listingstoolbar = By.XPath("//div[@class='product-details__listings-toolbar']");
        public void IsListingstoolbarExist()
        {
            _actionMethods.AssertElementIsDisplayed(Listingstoolbar, "Sort By and Listings Per Page");
        }
    }







    }
