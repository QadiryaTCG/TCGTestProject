using OpenQA.Selenium;

namespace Framework.Base
{
    public class DriverContext
    {
        private static IWebDriver _driver;

        public static IWebDriver driver
        {
            get
            {
                return _driver;
            }

            set
            {
                _driver = value;
            }
        }

        public BrowserType Browser { get; set; }

    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
