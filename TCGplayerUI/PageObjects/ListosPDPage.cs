using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects.MarketPlace
{
    public class ListosPDPage : StartBrowser
    {
        private ActionMethods _actionMethods;
        public ListosPDPage(ThreadLocal<IWebDriver> driver)
        {
            ListosPDPage.driver = driver;
            _actionMethods = new ActionMethods();
        }

        //Custom listing title display
        By Customtitle = By.XPath("//h1[@class='custom-listing__title']");
        public void IsCustomTitleExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Customtitle, "Product Title", 10);
        }

        //Add To Cart button display
        By AddToCartbtn = By.XPath("//button[@class='btn btn-sm product-listing__add-to-cart']");
        public void IsAddToCartExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(AddToCartbtn, "Add To Cart", 10);
        }

        // custom listing pricing display
        By Customlistingpricing = By.XPath("//div[@class='custom-listing__pricing']");
        public void IsCustompricingExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Customlistingpricing, "Custom Pricing", 10);
        }

        //Seller name display
        By SellerName = By.XPath("//section[@class='custom-listing__seller']//a[@class='seller__name']");
        public void IsSellerNameExist()
        {
            _actionMethods.AssertElementIsDisplayed(SellerName, "Seller Name");
        }

        //Report tab display
        By ReportTab = By.XPath("//a[@class='custom-listing__report-this-link']");
        public void IsReportTabExist()
        {
            _actionMethods.AssertElementIsDisplayed(ReportTab, "Report This");
        }
        By DetailsTab = By.XPath("//a[text()='Details']");
        public void ClickOnDetailsTab()
        {
            _actionMethods.Click(DetailsTab, "Details");
        }

        //After clicking on Details verify display for product name , set name ,condition,product description
        By ProductSetName = By.XPath("//div[@class='tab-content']//div[@class='custom-listing__structured-product']");
        public void IsProductSetnameExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(ProductSetName, "Product and Set Name", 10);
        }

        //Condition display
        By Condition = By.XPath("//div[@class='custom-listing__condition']");
        public void IsConditionExist()
        {
            _actionMethods.AssertElementIsDisplayed(Condition, "Product Condition");
        }

        //Product description display
        By ProductDescription = By.XPath("//dl[@class='product-description']");
        public void IsProductDescriptionExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(ProductDescription, "Product Description", 10);
        }
    }
}