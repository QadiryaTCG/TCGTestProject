using AventStack.ExtentReports;
using Framework.Base;
using Framework.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace TCGplayerUI.CustomMethods
{

    public class ActionMethods
    {
        //IWebDriver driver;
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public ActionMethods()
        {
            driver = StartBrowser.driver; /*(ThreadLocal<IWebDriver>)driver.Value;*/
        }


        /// <summary>
        /// Click Actions
        /// </summary>
        //Click Action
        public void Click(By locator, string element)
        {
            try
            {
                driver.Value.FindElement(locator).Click();
                StartBrowser.childTest.Pass("Successfully clicked on :" + element);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to click on :" + element,
                MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }
        //Enter Text
        public void EnterText(By locator, string element, string text)
        {
            try
            {
                driver.Value.FindElement(locator).SendKeys(text);
                StartBrowser.childTest.Pass("Successfully typed in :" + element + " With data : " + text);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to type in :" + element + "With data : " + text,
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        public String ScreenShot()
        {
            return ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
        }

    }
}



