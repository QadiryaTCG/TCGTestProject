using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects.MarketPlace
{
   public class NotaPage : StartBrowser
    {
        private ActionMethods _actionMethods;
        public NotaPage(ThreadLocal<IWebDriver> driver)
        {
            NotaPage.driver = driver;
            _actionMethods = new ActionMethods();
        }

        //404 image display
        By img404 = By.XPath("//img[@class='martech-not-found-page--image']");
        public void Is404ImageExist()
        {
            _actionMethods.AssertEleIsDisplayed(img404, "404");
        }

        // Text message display
        By txtSorryMessage = By.XPath("//h1[' Sorry, we couldn’t find that page.']");
        public void IsSorryMessageExist()
        {
            _actionMethods.AssertEleIsDisplayed(txtSorryMessage, "Sorry, we couldn’t find that page");
        }

        // Click on TCG homepage
        By lnkTCGHomePage = By.XPath("//a[text()='TCGplayer Homepage']");
        public void ClickOnTCGHomePage()
        {
            _actionMethods.ClickWithWait(lnkTCGHomePage, "TCGplayer Homepage", 20);
        }
    }
}
