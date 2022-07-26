using Framework.Base;
using OpenQA.Selenium;
using System.Threading;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects.MarketPlace
{
    public class LoginPage : StartBrowser
    {
        private ActionMethods _actionMethods;
        public LoginPage(ThreadLocal<IWebDriver> driver)
        {
            LoginPage.driver = driver;
            // PageFactory.InitElements(driver, this);
            _actionMethods = new ActionMethods();
        }

        // Enter Email and Password
        By txtUserName = By.XPath("//input[@name='Email']");
        By txtPassword = By.XPath("//input[@name='Password']");
        public void EnterUserNameAndPassword(string username, string password)
        {
            Thread.Sleep(3000);
            _actionMethods.EnterText(txtUserName, "Email", username);
            _actionMethods.EnterText(txtPassword, "Password", password);
        }
        // Enter only Email
        public void EnterEmail(string username)
        {
            _actionMethods.EnterText(txtUserName, "Email", username);
        }
        // Enter only password
        public void EnterPassword(string password)
        {
            _actionMethods.EnterText(txtPassword, "Password", password);
        }
        // By cbxRecaptcha = By.XPath("//*[@title='reCAPTCHA']"); --- This didn't work sometimes
        By chkRecaptcha = By.XPath("//*[@id='signInForm']/div[4]/div/div");
        public void ClickRecaptchaCheckbox()
        {
            if (_actionMethods.IsElePresent(chkRecaptcha, "reCaptcha"))
            {
                _actionMethods.ClickWithWait(chkRecaptcha, "Recaptcha for Testing purpose", 30);
            }
        }

        By btnSignIn = By.XPath("//button[@type='submit']");

        public void ClickSignIn()
        {
            _actionMethods.ClickWithWait(btnSignIn, "SignIn", 30);
        }
    }
}

