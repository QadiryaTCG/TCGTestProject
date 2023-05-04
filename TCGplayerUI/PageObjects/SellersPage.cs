using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects.MarketPlace
{
   public class SellersPage : StartBrowser
    {
        private ActionMethods _actionMethods;

        public SellersPage(ThreadLocal<IWebDriver> driver)
        {
            SellersPage.driver = driver;
            _actionMethods = new ActionMethods();
        }

        //Verify Seller Name search display
        By SellerNamesearch = By.XPath("//input[@id='SellerName']");
        public void IsSellerNamesearchExist()
        {
             _actionMethods.AssertElementIsDisplayedWithWait(SellerNamesearch, "Enter a Seller's Name",30);
        }
        //Verify checkboxelist like Direct by TCGPlayer , Certified Hobby Shops...display
        By Checkboxlist = By.XPath("//ul[@class='checkboxList']");
        public void IsCheckboxesExist()
        {
           _actionMethods.AssertElementIsDisplayed(Checkboxlist, "Direct,Certified,Gold Star");
        }

          By SellerName = By.XPath("//input[@id='SellerName']");
        public void EnterSellerName(string sellername)
        {
            _actionMethods.EnterText(SellerName, "SellerName", sellername);
        }

        //Click on Search button
        By Searchbtn =By.XPath("//input[@class='greenButton']");
        public void ClickOnSearch()
        {
            _actionMethods.Click(Searchbtn, "Search");
        }
        //Click on Shop This Seller
       By ShopThisSellerbtn =By.XPath("//button[@class='largeBlueButton2']");
        public void ClickOnShopThisSeller()
        {
            _actionMethods.ClickWithWait(ShopThisSellerbtn, "Shop This Seller",30);
        }
 




 
    }
}
