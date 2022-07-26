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
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public ActionMethods()
        {
            driver = StartBrowser.driver;
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

        //Click with wait for element to be clickable
        public void ClickWithWait(By locator, string element, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
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
        //////////////////**********///////////////


        /// <summary>
        /// Assertion Methods
        /// </summary>
       //Assert checkbox is selected
        public bool AssertCheckboxIsSelected(By locator)
        {
            try
            {
                Assert.IsTrue(driver.Value.FindElement(locator).Selected);
                StartBrowser.childTest.Pass("Checkbox is selected. Assert passed");
                return true;
            }
            catch
            {
                Console.WriteLine("Checkbox is not selected");
                StartBrowser.childTest.Fail("Checkbox is not selected. Assert failed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.IsTrue(false);
                return false;
            }
        }

        //Assert checkbox is NOT selected
        public bool AssertCheckboxIsNotSelected(By locator)
        {
            try
            {
                Assert.IsTrue(!driver.Value.FindElement(locator).Selected);
                StartBrowser.childTest.Pass("Checkbox is not selected. Assert passed");
                return true;
            }
            catch
            {
                Console.WriteLine("Checkbox is selected. Assert failed");
                StartBrowser.childTest.Fail("Checkbox is selected. Assert failed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.IsTrue(false);
                return false;
            }
        }
        // To be Discarded!!!!!
        //Assert element is displayed on page. (Not just in the DOM.)  
        public bool AssertEleIsDisplayed(By locator, String elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Displayed;
                Assert.IsTrue(value == true);
                StartBrowser.childTest.Pass("Element : " + elementName + " is displayed on the UI.  Assert passed.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not displayed on the page.");
                StartBrowser.childTest.Fail("Element : " + elementName + " is not displayed on the UI.  Assert failed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                Assert.IsTrue(false);
                throw e;
            }
        }

        /// !!!!!!Please use this method ONLY!!!!!!!!
        //Assert element is displayed on page. (Not just in the DOM.)  
        public void AssertElementIsDisplayed(By locator, String elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Displayed;
                Assert.IsTrue(value == true);
                StartBrowser.childTest.Pass("Element : " + elementName + " is displayed on the UI.  Assert passed.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not displayed on the page.");
                StartBrowser.childTest.Fail("Element : " + elementName + " is not displayed on the UI.  Assert failed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                Assert.IsTrue(false);
                throw e;
            }
        }

        //This method is used by the AssertElementIsNotDisplayed(By locator, String elementName) below.
        //It determines if an element is displayed on the UI, not just in the DOM.  If it is displayed, it returns true.  If not, it returns false. 
        //Use this to determine if a item is displayed on the page in case you only need to interact with it if it is diplayed, not assert it is displayed..  (Example: Storefront Continue As Buyer button.)
        public bool ElementIsDisplayed(By locator)
        {
            try
            {
                return driver.Value.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //Use with ElementIsDisplayed(By locator) method above.  Need to determine if an element is displayed on the UI in a seperate method and then call that method within this method.
        //If driver.Value.FindElement(locator).Displayed returns false, the code immediately advances to the catch portion.
        //This does not return a bool value.  The assert is captured in the report and will fail or pass.
        public void AssertEleIsNotDisplayed(By locator, String elementName)
        {
            if (false == ElementIsDisplayed(locator))
            {
                StartBrowser.childTest.Pass("Element : " + elementName + " is not displayed on the UI.  Not expecting it to be displayed.  Assert passed.");
            }
            else
            {
                StartBrowser.childTest.Fail("Element : " + elementName + " is displayed on the UI.  Not expecting it to be displayed.  Assert failed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.True(false);
            }
        }

        //Assert element is displayed on page. (Not just in the DOM.)  It includes a wait since some elements are loaded during runtime.
        public bool AssertEleIsDisplayedWithWait(By locator, String elementName, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                bool value = driver.Value.FindElement(locator).Displayed;
                Assert.IsTrue(value == true);
                StartBrowser.childTest.Pass("Element : " + elementName + " is displayed on the UI. Assert passed.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not displayed on the page.");
                StartBrowser.childTest.Fail("Element : " + elementName + " is not displayed on the UI. Assert failed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                Assert.IsTrue(false);
                throw e;
            }
        }

        /// Please Use This Method!!!//////
        //Assert element is displayed on page. (Not just in the DOM.)  It includes a wait since some elements are loaded during runtime.
        public void AssertElementIsDisplayedWithWait(By locator, String elementName, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                bool value = driver.Value.FindElement(locator).Displayed;
                Assert.IsTrue(value == true);
                StartBrowser.childTest.Pass("Element : " + elementName + " is displayed on the UI. Assert passed.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not displayed on the page.");
                StartBrowser.childTest.Fail("Element : " + elementName + " is not displayed on the UI.  Assert failed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                Assert.IsTrue(false);
                throw e;
            }
        }

        //Assert element is not displayed on page.  It includes a wait since some elements are loaded during runtime.
        public bool AssertEleIsNotDisplayedWithWait(By locator, String elementName, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                bool value = !driver.Value.FindElement(locator).Displayed;
                Assert.IsTrue(value == true);
                StartBrowser.childTest.Pass("Element : " + elementName + " is not displayed on the UI, as expected. Assert passed.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is displayed on the page but shouldnt be.");
                StartBrowser.childTest.Fail("Element : " + elementName + " is displayed on the UI but shouldnt be. Assert failed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                Assert.IsTrue(false);
                throw e;
            }
        }

        //Assert an element is selected.
        public void AssertElementIsSelected(By locator, string elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Selected;
                if (value == true)
                {
                    StartBrowser.childTest.Pass("Element :" + elementName + " is selected.");
                }
                else
                {
                    StartBrowser.childTest.Fail("Element :" + elementName + " is not selected.  It should be selected", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                    Assert.True(false);
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail(e);
                Assert.True(false);
                throw e;
            }
        }

        //Assert an element is selected.
        public void AssertElementIsNotSelected(By locator, string elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Selected;
                if (value == false)
                {
                    StartBrowser.childTest.Pass("Element :" + elementName + " is not selected.");
                }
                else
                {
                    StartBrowser.childTest.Fail("Element :" + elementName + " is selected. It should not be selected", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                    Assert.True(false);
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail(e);
                Assert.True(false);
                throw e;
            }
        }

        //Assert an element is enabled.
        public void AssertElementIsEnabled(By locator, string elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Enabled;
                if (value == true)
                {
                    StartBrowser.childTest.Pass("Element :" + elementName + " is enabled as expected.");
                }
                else
                {
                    StartBrowser.childTest.Fail("Element :" + elementName + " is disabled. It should be enabled.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail(e);
                Assert.True(false);
                throw e;
            }
        }

        //Assert an element is disabled.
        public void AssertElementIsDisabled(By locator, string elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Enabled;
                if (value == false)
                {
                    StartBrowser.childTest.Pass("Element :" + elementName + " is disabled as expected.");
                }
                else
                {
                    StartBrowser.childTest.Fail("Element :" + elementName + " is enabled.  It should be disabled.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail(e);
                Assert.True(false);
                throw e;
            }
        }

        //Compare two values only if they are on same page, returns "true" if they are equal, returns "false" if they are not euqal
        public bool AssertTwoValuesAreEqual(By locator_expected, By locator_actual)
        {
            String expected_value = driver.Value.FindElement(locator_expected).Text;
            String actual_value = driver.Value.FindElement(locator_actual).Text;
            try
            {
                Assert.That(expected_value, Is.EqualTo(actual_value).IgnoreCase);
                StartBrowser.childTest.Info("Expected value: " + expected_value + ". Actual value: " + actual_value + ". Two values match.");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Value not matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info("Expected value: " + expected_value + ". Actual value: " + actual_value + ". Two values do not match.");
                Assert.Fail();
                throw e;
            }
        }

        //Assert two strings are Equal.
        public bool AssertTwoStringsAreEqual(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
                StartBrowser.childTest.Pass("Expected value: " + expected + ". Actual value: " + actual + ". The values match.");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Expected value: " + expected + ". Actual value: " + actual + ". The values do not match.");
                StartBrowser.childTest.Fail("Value not matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert two strings with new line are Equal.
        public bool AssertTwoStringsWithNewLineAreEqual(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(Regex.Replace(expected, @"\s+", " ").Trim(), Regex.Replace(actual, @"\s+", " ").Trim());
                StartBrowser.childTest.Pass("Expected value: " + expected + ". Actual value: " + actual + ". The values match.");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Expected value: " + expected + ". Actual value: " + actual + ". The values do not match.");
                StartBrowser.childTest.Fail("Value not matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert two doubles are equal.
        public bool AssertTwoDoublesAreEqual(double expected, double actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
                StartBrowser.childTest.Pass("Expected value: " + expected + ". Actual value: " + actual + ". The values match.");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Expected value: " + expected + ". Actual value: " + actual + ". The values do not match.");
                StartBrowser.childTest.Fail("Value not matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert two numbers are equal
        public bool AssertTwoNumbersAreEqual(int expected, int actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
                StartBrowser.childTest.Pass("Expected value: " + expected + ". Actual value: " + actual + ". The values match.");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Expected value: " + expected + ". Actual value: " + actual + ". The values do not match.");
                StartBrowser.childTest.Fail("Value not matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert two numbers are not equal
        public bool AssertTwoNumbersAreNotEqual(int expected, int actual)
        {
            try
            {
                Assert.AreNotEqual(expected, actual);
                StartBrowser.childTest.Pass("Expected value: " + expected + ". Actual value: " + actual + ". The values do not match as expected");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Expected value: " + expected + ". Actual value: " + actual + ". The values match.  They should not.");
                StartBrowser.childTest.Fail("Values matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert two strings are not equal
        public bool AssertTwoStringsAreNotEqual(string expected, string actual)
        {
            try
            {
                Assert.AreNotEqual(expected, actual);
                StartBrowser.childTest.Pass("Expected value: " + expected + ". Actual value: " + actual + ". The values do not match as expected.");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Expected value: " + expected + ". Actual value: " + actual + ". The values match.  They should not.");
                StartBrowser.childTest.Fail("Values matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //assertGreaterOrEqual – This assertion has two parameters. A comparison is done between the first and second parameter.
        //In case the first parameter is greater than or equal to the second one, the test case is considered a pass; else the test case is failed.
        public bool AssertGreaterOrEqual(int a, int b)
        {
            try
            {
                Assert.GreaterOrEqual(a, b);
                StartBrowser.childTest.Pass(a + " is greater than or equal to " + b);
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail(a + " is not greater than or equal to " + b);
                StartBrowser.childTest.Fail(a + " is not greater than or equal to " + b, MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }


        //assertLessOrEqual – This assertion has two parameters. A comparison is done between the first and second parameter.
        //In case the first parameter is less than or equal to the second one, the test case is considered a pass; else the test case is failed.
        public bool AssertLessOrEqual(int a, int b)
        {
            try
            {
                Assert.LessOrEqual(a, b);
                StartBrowser.childTest.Pass(a + " is less than or equal to " + b);
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail(a + " is not less than or equal to " + b);
                StartBrowser.childTest.Fail(a + " is not less than or equal to " + b, MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert a string contains a value.
        public bool AssertAStringContainsAValue(string value, string subString)
        {
            try
            {
                Assert.IsTrue((value).Contains(subString));
                StartBrowser.childTest.Pass("String: '" + value + "' contains substring: '" + subString + "'");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("String: '" + value + "' does not contain substring: '" + subString + "'");
                StartBrowser.childTest.Fail("Value not matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert a string contains a value.
        public bool AssertAStringContainsAValueIgnoreCase(string value, string subString)
        {
            try
            {
                Assert.IsTrue(value.Contains(subString, StringComparison.OrdinalIgnoreCase));
                StartBrowser.childTest.Pass("String: '" + value + "' contains substring: '" + subString + "'");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("String: '" + value + "' does not contain substring: '" + subString + "'");
                StartBrowser.childTest.Fail("Value not matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert a string does NOT contains a value.
        public bool AssertAStringDoesNotContainsAValueIgnoreCase(string value, string subString)
        {
            try
            {
                Assert.IsTrue(!value.Contains(subString, StringComparison.OrdinalIgnoreCase));
                StartBrowser.childTest.Pass("String: '" + value + "' contains substring: '" + subString + "'");
                return true;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("String: '" + value + "' does not contain substring: '" + subString + "'");
                StartBrowser.childTest.Fail("Value not matched", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                Assert.Fail();
                throw e;
            }
        }

        //Assert only the item count of one array to the item count in a second array
        public void AssertArrayItemCountsEqual(string[] arr1, string[] arr2)
        {
            try
            {
                Assert.AreEqual(arr1.Count(), arr2.Count());
                StartBrowser.childTest.Pass("Array One has " + arr1.Count() + " items.  Array Two has  " + arr2.Count() + " items.  Counts match.");
            }
            catch (Exception)
            {
                StartBrowser.childTest.Fail("Array One has " + arr1.Count() + " items.  Array Two has  " + arr2.Count() + " items. Counts do not match.");
                Assert.Fail();
            }
        }

        //Assert only the values in one array to the values in a second array
        public void AssertArrayValuesEqual(string[] arr1, string[] arr2)
        {
            int ItemSize = arr1.Count();
            for (int i = 0; i < ItemSize; i++)
                try
                {
                    Assert.AreEqual(arr1[i], arr2[i]);
                    StartBrowser.childTest.Pass("Array 1 value of '" + arr1[i] + "' equals array 2 value of '" + arr2[i] + "'");
                }
                catch (Exception e)
                {
                    StartBrowser.childTest.Fail("Array 1 value of '" + arr1[i] + "' does not equal array 2 value of '" + arr2[i] + "'");
                    Assert.Fail();
                    throw e;
                }
        }
        //////////////**************///////////////


        /// <summary>
        /// Text Actions ///////////
        /// </summary>
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

        //Clear text it will clear a text from text box
        public void ClearText(By locator, string element)
        {
            try
            {
                driver.Value.FindElement(locator).Clear();
                StartBrowser.childTest.Pass("Successfully clear text:" + element);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable tonclear text :" + element,
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Clear text using action method
        public void ClearTextUsingActionMethod(By locator, string element)
        {
            try
            {
                Actions actions = new Actions(driver.Value);
                IWebElement ele = driver.Value.FindElement(locator);
                actions.Click(ele)
                    .KeyDown(Keys.Control)
                    .SendKeys("a")
                    .KeyUp(Keys.Control)
                    .SendKeys(Keys.Backspace)
                    .Build()
                    .Perform();

                StartBrowser.childTest.Pass("Successfully cleared text:" + element);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to clear text :" + element,
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Verify Text
        public string GetText(By locator)
        {
            try
            {
                String x = driver.Value.FindElement(locator).Text;
                StartBrowser.childTest.Pass("Text is :" + x);
                return x;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("unable to return text", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                return null;
            }
        }

        //Get text if it is displayed.  Use this if waiting for text to appear.  If it does not, we do not want failures to appear in the test resutls.
        public string GetTextIfDisplayed(By locator)
        {
            try
            {
                String x = driver.Value.FindElement(locator).Text;
                StartBrowser.childTest.Info("Text is :" + x);
                return x;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Info("Text is not displayed at this time.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                return null;
            }
        }

        //Clear text then Enter Text
        public void ClearThenEnterText(By locator, string element, string text)
        {
            try
            {
                driver.Value.FindElement(locator).Clear();
                driver.Value.FindElement(locator).SendKeys(text);
                StartBrowser.childTest.Pass("Successfully typed in :" + element + " With data : " + text);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to clear or type in :" + element + "With data : " + text,
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Enter one character at a time from a string.  Wait a short time between each key stroke.
        public void EnterOneCharacterAtATime(By locator, string elementName, string stringToEnter)
        {
            try
            {
                foreach (char c in stringToEnter)
                {
                    driver.Value.FindElement(locator).SendKeys(c.ToString());
                    Thread.Sleep(50);
                }
                StartBrowser.childTest.Pass("Entered '" + stringToEnter + "' into " + elementName);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Issue occured.  Could not enter '" + stringToEnter + "' into " + elementName);
                throw e;
            }
        }
        ////////////************///////////////


        /// <summary>
        /// Key Actions
        /// </summary>
        //Enter Key method. This method will press the enter key like keyboard
        public void EnterKey(By locator)
        {
            try
            {
                driver.Value.FindElement(locator).SendKeys(Keys.Enter);
                StartBrowser.childTest.Pass("Successfully pressed the Enter Key");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to pressed the Enter Key",
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Up Key method. This method will press the up key like keyboard
        public void UpKey(By locator)
        {
            try
            {
                driver.Value.FindElement(locator).SendKeys(Keys.Up);
                StartBrowser.childTest.Pass("Successfully pressed the Up Key");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to pressed the Up Key",
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Down Key method. This method will press the down key like keyboard
        public void DownKey(By locator)
        {
            try
            {
                driver.Value.FindElement(locator).SendKeys(Keys.Down);
                StartBrowser.childTest.Pass("Successfully pressed the Down Key");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to pressed the Down Key",
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Will loop through and click the down arrow as may times as needed.  Then click the enter key.
        public void ClickDownArrowThenEnterKey(int loop, By locator, string element)
        {
            try
            {
                Actions actions = new Actions(driver.Value);
                IWebElement ele = driver.Value.FindElement(locator);

                int x = 0;
                actions.MoveToElement(ele);
                while (x < loop)
                {
                    actions.SendKeys(Keys.Down);
                    x++;
                }
                actions.SendKeys(Keys.Enter);
                actions.Build();
                actions.Perform();

                StartBrowser.childTest.Pass("Successfully clicked the Down Arrow key and Enter key for: " + element);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to click the Down Arrow key and Enter key for: " + element,
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        public void ClickEnterKey(By locator, string element)
        {
            try
            {
                Actions actions = new Actions(driver.Value);
                IWebElement ele = driver.Value.FindElement(locator);
                actions.MoveToElement(ele)
                    .SendKeys(Keys.Enter)
                    .Build()
                    .Perform();

                StartBrowser.childTest.Pass("Successfully clicked the Enter key for: " + element);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to click the Enter key for: " + element,
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        public void BackspaceKey(By locator)
        {
            try
            {
                driver.Value.FindElement(locator).SendKeys(Keys.Backspace);
                StartBrowser.childTest.Pass("Successfully pressed the Backspace Key");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to pressed the Backspace Key",
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }
        /////////////***********//////////


        /// <summary>
        /// Select Actions
        /// </summary>
        //Select by Visible Text from drop down
        public void SelectByText(By locator, String visibleText)
        {
            try
            {
                IWebElement dd = driver.Value.FindElement(locator);
                SelectElement s = new SelectElement(dd);
                s.SelectByText(visibleText);
                StartBrowser.childTest.Pass("Selected value of: " + visibleText + " from dropdown");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to select value of: " + visibleText + " from dropdown", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Select by Value from drop down
        public void SelectByValue(By locator, String value)
        {
            try
            {
                IWebElement dd = driver.Value.FindElement(locator);
                SelectElement s = new SelectElement(dd);
                s.SelectByValue(value);
                StartBrowser.childTest.Pass("Selected value of: " + value + " from dropdown");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to select value of: " + value + " from dropdown", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Perform Select by Index from dropdown
        public void SelectByIndex(By locator, int index)
        {
            try
            {
                IWebElement dd = driver.Value.FindElement(locator);
                SelectElement s = new SelectElement(dd);
                s.SelectByIndex(index);
                StartBrowser.childTest.Pass("Selected value of: " + index + " from dropdown");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to select value of: " + index + " from dropdown", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }
        //////////////***************//////////////


        /// <summary>
        /// Checkbox Actions
        /// </summary>
        //Verify Checkboxes are selected by default
        public void CheckBoxesSelected(By locator)
        {
            try
            {
                Assert.IsTrue(driver.Value.FindElement(locator).Selected);
                StartBrowser.childTest.Pass("Checkbox is selected.");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Checkbox is not selected", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                throw e;
            }
        }

        //Verify Checkboxes are Not selected by default
        public void CheckBoxesNotSelected(By locator)
        {
            try
            {
                Assert.IsFalse(driver.Value.FindElement(locator).Selected);
                StartBrowser.childTest.Pass("Checkbox is not selected.");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Checkbox is selected. It should not be.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                throw e;
            }
        }

        // Get the checked checkboxes count and Unchecked checkboxes count
        public void CheckboxesCount(By locator)
        {
            try
            {
                ReadOnlyCollection<IWebElement> webElements = driver.Value.FindElements(locator);
                int checkedCount = 0;
                int uncheckedCount = 0;
                foreach (var element in webElements)
                {
                    if (element.Selected == true)
                        checkedCount++;

                    else
                        uncheckedCount++;

                }
                StartBrowser.childTest.Pass("Number of checked checkboxes are" + checkedCount);
                StartBrowser.childTest.Pass("Number of unchecked checkboxes are" + uncheckedCount);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Number of checked checkboxes are not available ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                throw e;
            }

        }


        //Assert if a checkbox are selected and return a bool value.  Do not want to fail the test.
        //Just want to know if the item is selected or not so the test can use the info to determine the next steps in the test.
        public bool IsCheckboxSelected(By locator, string elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Selected;
                if (value == true)
                {
                    StartBrowser.childTest.Info(elementName + " is checked");
                    return true;
                }
                else
                {
                    StartBrowser.childTest.Info(elementName + " is not checked");
                    return false;
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Issue locating " + elementName, MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                throw e;
            }
        }

        //Verify if an item is selected.  Return true or false.
        public bool IsSelected(By locator, string elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Selected;
                if (value == true)
                {
                    StartBrowser.childTest.Info("Element :" + elementName + " is selected");
                    return true;
                }
                else
                {
                    StartBrowser.childTest.Info("Element :" + elementName + " is not selected");
                    return false;
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Info("Element :" + elementName + " is not selected", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                return false;
                throw e;
            }
        }

        //Verify if an object is enabled. Return true or false. Use this if you need to work with the element on the page.  Not to assert it is displayed.
        //This will get the value (true or false) if object is enabled. Use this if you need to wait until an object is enabled. 
        public bool IsEnabled(By locator, string elementName)
        {
            try
            {
                bool value = driver.Value.FindElement(locator).Enabled;
                if (value == true)
                {
                    StartBrowser.childTest.Info("Element :" + elementName + " is enabled");
                    return true;
                }
                else
                {
                    StartBrowser.childTest.Info("Element :" + elementName + " is not enabled");
                    return false;
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Info("Element :" + elementName + " is not enabled", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                return false;
                throw e;
            }
        }

        ///////////////*************//////////////


        /// <summary>
        /// Mouse Actions
        /// </summary>
        //Perform mouse hover and click on submenu
        public void MouseHoverAndClickSubMenu(By menulocator, By subMenuLocator, String menu, String submenu)
        {
            try
            {
                Actions act = new Actions(driver.Value);
                IWebElement ele = driver.Value.FindElement(menulocator);
                act.MoveToElement(ele).Build().Perform();
                Thread.Sleep(3000);
                driver.Value.FindElement(subMenuLocator).Click();
                StartBrowser.childTest.Pass("Successfully mouse hover on Menu: " + menu + " and clicked on submenu");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to mouse hover on Menu: " + menu + " and unable to click on submenu", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;

            }
        }

        //Perform mouse hover with time
        public void MouseHoverWithWait(By menulocator, String menu, int waitTime)
        {
            try
            {
                Actions act = new Actions(driver.Value);
                IWebElement ele = driver.Value.FindElement(menulocator);
                act.MoveToElement(ele).Build().Perform();
                StartBrowser.childTest.Pass("Successfully mouse hover on Menu: " + menu);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to mouse hover on Menu: " + menu, MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Hover over element on page.  Not a menu item.  Created a new method so detail written to report does not mention menu
        public void MouseOverObject(By locator, string element)
        {
            try
            {
                Actions act = new Actions(driver.Value);
                IWebElement ele = driver.Value.FindElement(locator);
                act.MoveToElement(ele).Build().Perform();
                StartBrowser.childTest.Pass("Successfully mouse hover over " + element);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to mouse hover over " + element, MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }
        ///////////////////***************//////////////////


        /// <summary>
        /// Get Attribute Actions
        /// </summary>
        //GetAttribute value 
        public string GetattributeValue(By locator)
        {
            try
            {
                String x = driver.Value.FindElement(locator).GetAttribute("value");
                StartBrowser.childTest.Pass("Text is  :" + x);
                return x;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to return value attribute", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                return null;
            }
        }

        //GetAttribute placeholder
        public string GetattributePlaceholder(By locator)
        {
            try
            {
                String x = driver.Value.FindElement(locator).GetAttribute("placeholder");
                StartBrowser.childTest.Pass("Text is  :" + x);
                return x;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to return placeholder attribute", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                return null;
            }
        }

        //GetAttribute class
        public string GetattributeClass(By locator)
        {
            try
            {
                String x = driver.Value.FindElement(locator).GetAttribute("class");
                StartBrowser.childTest.Pass("Text is  :" + x);
                return x;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to return class attribute", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                return null;
            }
        }
        ///////////////****************//////////////


        /// <summary>
        /// Wait Actions 
        /// </summary>
        //If element has Overlay and you want to wait until it is clickable, then use the following javascript Executor method
        public void WaitUntiClickableJavascriptExcecutor(By locator, string element, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to click on :" + element,
                MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Wait until an object is clickable.
        public void WaitUntilClickable(By locator, String elementName, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
                StartBrowser.childTest.Pass("Element : " + elementName + " is clickable.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not clickable.");
                StartBrowser.childTest.Fail("Element : " + elementName + " is not clickable.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                throw e;
            }
        }

        //Wait for element to be present on UI
        public Boolean WaitEleVisible(By locator, String elementName, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

                StartBrowser.childTest.Pass("Element :" + elementName + " is present");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not present");
                StartBrowser.childTest.Info("Element :" + elementName + " is not present", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                return false;
                throw e;
            }
        }
        ///////////////************//////////////


        /// <summary>
        /// JavaScriptExecutor Methods
        /// </summary>
        //Scroll page using javascript Executor
        public void JavaScriptExecutorScrollPage(By locator)
        {
            try
            {
                var element = driver.Value.FindElement(locator);
                var script = "arguments[0].scrollIntoView(true);";
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(script, element);
                StartBrowser.childTest.Pass("Element :" + " Page Scroll");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Pass("Element :" + " page not Scroll", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
            }
        }

        //Scroll page up by value using javascript executor x = horizontal, y = vertical
        public void JavaScriptExecutorScroll(int x, int y)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(" + x + "," + y + ")");
            Thread.Sleep(2000);
        }

        //Scroll to bottom of page
        public void JavaScriptExecutorBottomOfPage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 0)");
        }

        //If element has Overlay and not able to click then use the following javascript Executor method
        public void JavaScriptExecutorClick(By locator, string element)
        {
            try
            {
                IWebElement ele = driver.Value.FindElement(locator);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", ele);
                StartBrowser.childTest.Pass("Successfully clicked on: " + element);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to click on :" + element,
               MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        // Create new event using JavaScript
        public void JavaScriptNewEvent(By locator, string element)
        {
            try
            {
                IWebElement ele = driver.Value.FindElement(locator);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].dispatchEvent(new Event('input', {bubbles:true}))", ele);
                StartBrowser.childTest.Pass("Successfully changed the date" + element);

            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unsuccessful to change the date" + element,
              MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }
        ///////////////////*************/////////////////


        /// <summary>
        /// Element Methods
        /// </summary>
        //Verify isElement present ,It will return true if the element is present otherwise false
        public Boolean IsElePresent(By locator, String elementName)
        {
            try
            {
                driver.Value.FindElement(locator);
                StartBrowser.childTest.Pass("Element :" + elementName + " is present");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not present");
                StartBrowser.childTest.Info("Element :" + elementName + " is not present", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                return false;
                throw e;
            }
        }

        //Verify isElement not present , if the element absent the test will pass 
        public Boolean IsElementAbsent(By locator, String element)
        {
            try
            {
                driver.Value.FindElement(locator);
                StartBrowser.childTest.Pass("Element :" + element + " is present", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                return false;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Pass("Element :" + element + " is not present");
                return true;
            }
        }

        // Wait for element present and verify element is present on the page
        public Boolean IsElePresentWithWait(By locator, String elementName, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                driver.Value.FindElement(locator);
                StartBrowser.childTest.Pass("Element :" + elementName + " is present");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not present");
                StartBrowser.childTest.Info("Element :" + elementName + " is not present", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                return false;
                throw e;
            }
        }

        //Verify if an element is displayed on the UI. (Not just in the DOM.)  Use this if you need to work with the element on the page.  Not to assert it is displayed.
        //This will get the value (true or false) if object is displayed on the the page. 
        //It can be used to indicate if an object is displayed on a page.  If you need to interact with an object, but it is not always displayed on the page because
        //it may be hidden until a portion of the screen until that portion is expanded, use this method in an if else statement.  If true, the object is displayed, if not,
        //then the test will know something else needs to occur before the object is displayed and the test continues.
        //The else portion of this method is also a 'Pass' because we do not want the test to fail if the object is not found.
        //You could then use the true or false values in an separate assert in a test,
        //but if you want to assert if an object is displayed on the UI, use the AssertEleIsDisplayed(By locator, String elementName)
        public Boolean IsEleDisplayed(By locator, String elementName)
        {
            try
            {
                bool x = driver.Value.FindElement(locator).Displayed;
                if (x == true)
                {
                    StartBrowser.childTest.Pass("Element :" + elementName + " is present");
                    return true;
                }
                else
                {
                    StartBrowser.childTest.Pass("Element :" + elementName + " is not present");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not present");
                StartBrowser.childTest.Info("Element :" + elementName + " is not present", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                return false;
                throw e;
            }
        }

        //Verify if Element is Displayed on page. (Not just in the DOM.)  Use this if you need to work with the element on the page.  Not just assert it is displayed
        public Boolean IsEleDisplayedWithWait(By locator, String elementName, int waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(waitTime));
                IWebElement ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                bool x = driver.Value.FindElement(locator).Displayed;
                if (x == true)
                {
                    StartBrowser.childTest.Pass("Element :" + elementName + " is present");
                    return true;
                }
                else
                {
                    StartBrowser.childTest.Pass("Element :" + elementName + " is not present");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not present");
                StartBrowser.childTest.Info("Element :" + elementName + " is not present", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                return false;
                throw e;
            }
        }

        //Return the count of an element
        public int ReturnElementCount(By locator)
        {
            try
            {
                IList<IWebElement> elements = driver.Value.FindElements(locator);
                int ItemValue = elements.Count;
                StartBrowser.childTest.Pass("Count is :" + ItemValue);
                return ItemValue;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to get count", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }
        ////////////////***********////////////////


        /// <summary>
        /// Generic Methods
        /// </summary>
        //Navigate to application
        public void NavigationToApplication(String baseUrl)
        {
            try
            {
                driver.Value.Url = baseUrl;
                StartBrowser.childTest.Pass("Successfully navigated to :" + baseUrl);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to navigated to :" + baseUrl);
                throw e;
            }
        }

        //Get all drop down option 
        public void GetAllDropdownOptions(By locator)
        {
            try
            {
                IWebElement elem = driver.Value.FindElement(locator);
                SelectElement selectlist = new SelectElement(elem);
                IList<IWebElement> options = selectlist.Options;
                int ItemSize = options.Count;
                for (int i = 0; i < ItemSize; i++)
                {
                    String ItemValue = options.ElementAt(i).Text;
                    StartBrowser.childTest.Pass("Option values " + ItemValue + " value from dropdown");
                    Console.WriteLine(ItemValue);
                }
            }
            catch (Exception e)
            {
                String ItemValue = null;
                StartBrowser.childTest.Fail("Unable to get option values" + ItemValue + "value from dropdown", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Switch Iframes
        public void SwitchIframe(By locator, string element)
        {
            try
            {
                IWebElement my_frame = driver.Value.FindElement(locator);
                driver.Value.SwitchTo().Frame(my_frame);
                StartBrowser.childTest.Pass("Successfully click on iframe " + element);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to click on iframe: " + element, MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Get values from a drop down and place in an array.
        public string[] PutAllDropdownOptionsIntoAnArray(By locator, String elementName)
        {
            try
            {
                IWebElement elem = driver.Value.FindElement(locator);
                SelectElement selectlist = new SelectElement(elem);
                IList<IWebElement> options = selectlist.Options;
                int itemSize = options.Count;
                int arrarySize = itemSize;
                string[] array = new string[arrarySize];
                for (int i = 0; i < itemSize; i++)
                {
                    string itemValue = options.ElementAt(i).Text;
                    array[i] = itemValue;
                }
                StartBrowser.childTest.Pass("Values from the " + elementName + " dropdown were put into an array.");
                return array;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Issue occured.  The values from the  " + elementName + " dropdown could not be put into an array.");
                throw e;
            }
        }

        //Assert both the item count and values of one array to the item count and values in a second array
        public void ArrayCountAndValues(string[] arr1, string[] arr2)
        {
            try
            {
                Assert.AreEqual(arr1.Count(), arr2.Count());
                StartBrowser.childTest.Pass("Array One has " + arr1.Count() + " items.  Array Two has  " + arr2.Count() + " items.  Counts match.");
            }
            catch (Exception)
            {
                StartBrowser.childTest.Fail("Array One has " + arr1.Count() + " items.  Array Two has  " + arr2.Count() + " items. Counts do not match.");
                Assert.Fail();
            }

            int ItemSize = arr1.Count();
            for (int i = 0; i < ItemSize; i++)
                try
                {
                    Assert.AreEqual(arr1[i], arr2[i]);
                    StartBrowser.childTest.Pass("Array 1 value of '" + arr1[i] + "' equals array 2 value of '" + arr2[i] + "'");
                }
                catch (Exception e)
                {
                    StartBrowser.childTest.Fail("Array 1 value of '" + arr1[i] + "' does not equal array 2 value of '" + arr2[i] + "'");
                    Assert.Fail();
                    throw e;
                }
        }

        //Get table row count
        public int GetTableRowCount(By locator)
        {
            try
            {
                int x = driver.Value.FindElements(locator).Count;
                return x;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to optain table count",
                MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        // Retrieve a substring
        // Using locator to get the original string from an element
        // Original string : before + newString(Substring) + after
        public string RetrieveSubstring(By locator, string before, string after)
        {
            try
            {
                string str = driver.Value.FindElement(locator).Text;
                int start = str.IndexOf(before) + before.Length;
                int end = str.IndexOf(after) - start;
                string subString = str.Substring(start, end);
                return subString;
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to retrieve substring", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Drag and drop with a simple Actions class method
        public void DragAndDropItem(By from_locator, By to_locator, string fromEleName, string toEleName)
        {
            try
            {
                Actions action = new Actions(driver.Value);
                IWebElement from_element = driver.Value.FindElement(from_locator);
                IWebElement to_element = driver.Value.FindElement(to_locator);
                action.DragAndDrop(from_element, to_element).Build().Perform();
                StartBrowser.childTest.Pass("Successfully dragNdropped " + fromEleName + "to " + toEleName);
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to dragNdropped " + fromEleName + "to " + toEleName + MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Drag and drop with multiple Actions class methods
        public void DragNDrop(By from_locator, By to_locator)
        {

            Actions action = new Actions(driver.Value);
            IWebElement from_element = driver.Value.FindElement(from_locator);
            IWebElement to_element = driver.Value.FindElement(to_locator);
            Point point = to_element.Location;
            int xcord = point.X;
            int ycord = point.Y;

            action.ClickAndHold(from_element).Perform();
            action.MoveByOffset(xcord / 2, ycord / 2).Perform();
            action.MoveToElement(to_element).Perform();
            action.Release(to_element).Perform();
        }

        // Open new tab using right click
        public void OpenNewTab(By locator)
        {
            try
            {
                Actions builder = new Actions(driver.Value);
                IWebElement rightclick = driver.Value.FindElement(locator);
                builder.ContextClick(rightclick)
                .KeyDown(Keys.Control)
               .KeyDown(Keys.Shift).Click(rightclick)
               .KeyUp(Keys.Control).KeyUp(Keys.Shift).Perform();
                StartBrowser.childTest.Pass("Right clicked and Successfully Opened a New Tab");
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to Open a New Tab", MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());
                StartBrowser.childTest.Fail(e);
                throw e;
            }
        }

        //Gets current date.  Removes the leading zero in the month if there is one.  (Example: 08/ = 8/)
        public string MonthDropLeadingZero()
        {
            try
            {
                //get today's date
                DateTime d = DateTime.Now;
                string dateString = d.ToString("MM/dd/yyyy");
                //Get first character in the date.
                char char0 = dateString[0];
                string charString = char0.ToString();
                if (charString == "0")
                {
                    //trims first character.  Will return 1 character value for the month plus the slash.  
                    string month = dateString.Substring(1, dateString.Length - 8);
                    return month;
                }
                else
                {
                    //trims the last 7 characters.  Will return a 2 character value for the month plus the slash.
                    string month = dateString.Substring(0, dateString.Length - 7);  //trims the last 7 characters.
                    return month;
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to retrieve current DateTime");
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }

        //Gets current date.  Removes the month and the leading zero in the day portion of the date if there is one.  (Example: 08/03/2021 = 3/2021)
        public string DayDropLeadingZero()
        {
            try
            {
                //get today's date
                DateTime d = DateTime.Now;
                string dateString = d.ToString("MM/dd/yyyy");
                //Get first character in the date.
                char char3 = dateString[3];
                string charString = char3.ToString();
                if (charString == "0")
                {
                    //trims first four characters.  Will return 1 character value for day, the slash and year.
                    string day = dateString.Substring(4, dateString.Length - 4);
                    return day;
                }
                else
                {
                    //trims first three characters.  Will return 2 characters value for day, the slash and year.
                    string day = dateString.Substring(3, dateString.Length - 3);
                    return day;
                }
            }
            catch (Exception e)
            {
                StartBrowser.childTest.Fail("Unable to retrieve current DateTime");
                StartBrowser.childTest.Info(e);
                throw e;
            }
        }


      


        public String ScreenShot()
        {
            return ((ITakesScreenshot)driver.Value).GetScreenshot().AsBase64EncodedString;
        }



    }

}