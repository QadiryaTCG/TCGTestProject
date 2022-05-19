using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects
{
    public class HomePage : StartBrowser
    {

        private ActionMethods _actionMethods;
        public HomePage(ThreadLocal<IWebDriver> driver)
        {
            HomePage.driver = driver;
            PageFactory.InitElements((IWebDriver)driver, this);
            _actionMethods = new ActionMethods();
        }



        By SignInlink = By.XPath("//span[@data-aid='headerSignInValue']");

        public void ClickOnSignIn()
        {
            _actionMethods.Click(SignInlink, "SigninLink");
        }
    }
}