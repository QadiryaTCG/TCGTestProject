using NUnit.Framework;
using Framework.Base;
using Framework.Helpers;
using System.Threading;
using System;
using System.IO;
using AventStack.ExtentReports.Reporter;
using TCGplayerUI.PageObjects.MarketPlace;

namespace TCGplayerUI.TestCases
{

    public class LoginTest : StartBrowser
    {

        HomePage homePage;
        LoginPage loginPage;
        public LoginTest(string profile, string environment) : base(profile, environment, SetUpClass.extent) { }
        [Test]
        [Category("Direct")]
        [Category("Smoke")]
        public void MPLoginTest()
        {

            Setup(SetUpClass.extent, "baseUrl");

            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
          

            StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Login For Direct Admin");
            Thread.Sleep(3000);
            homePage.ClosePopUp();
            homePage.ClickOnSignIn();
            homePage.IsmarketplaceHeaderExist();
            homePage.AssertShoppingCartDisplayed();
            homePage.AssertSearchBarDisplayed();
            homePage.AssertSpyGlassDisplayed();
        

        }
    }
}