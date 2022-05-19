using AventStack.ExtentReports;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Framework.Base;
using Framework.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Syroot.Windows.IO;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TCGplayerUI.CustomMethods;
using TCGplayerUI.PageObjects;
using TCGplayerUI.TestSetUp;

namespace TCGplayerUI.TestCases
{

    [TestFixture]
    public class LoginTest : StartBrowser
    {
        public LoginTest() : base(SetUpClass.extent) { }

        HomePage homepage;


        //This test verifies that the import/export buttons and tool tips appear on the Buylist Pricing Tool page.
        [Test]
        [Category("Smoke")]
        public void LTLogInTest()
        {
            Setup(SetUpClass.extent, "baseUrl");

            homepage = new HomePage(driver);

            StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Login To HomePage");

            Thread.Sleep(2000);
            homepage.ClickOnSignIn();

        }
    }

}