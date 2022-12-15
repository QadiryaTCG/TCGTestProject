using AventStack.ExtentReports;
using Framework.Config;
using Framework.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;


namespace Framework.Base
{

    [TestFixture]
   // [TestFixture("parallel", "safari")]
     [TestFixture("parallel", "chrome")]
    [Parallelizable(ParallelScope.All)]

    public class StartBrowser
    {
        protected static readonly object ConfigReader;
        public static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public string profile;
        public string environment;
        public String TC_Name;
        public ExtentTest _test;
        [ThreadStatic]
        public static ExtentTest parentTest;
        [ThreadStatic]
        public static ExtentTest childTest;
        public static string seleniumUri = "https://hub.lambdatest.com:443/wd/hub";
        public StartBrowser() { }

        public StartBrowser(AventStack.ExtentReports.ExtentReports tempExtent)
        {
            extent = tempExtent;
        }

        AventStack.ExtentReports.ExtentReports extent;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public StartBrowser(string profile, string environment, AventStack.ExtentReports.ExtentReports tempExtent)
        {
            extent = tempExtent;
            this.profile = profile;
            this.environment = environment;
        }
        //New Setup method that will use the URL files
        public void Setup(AventStack.ExtentReports.ExtentReports tempExtent, string url)
        {
            extent = tempExtent;
            ConfigReaders.LoadConfig();
            //Init();
            Console.WriteLine("Starting Tests");
            var file = JsonHelpers.GetJsonDataEnv("Urls.json");
            string testCaseUrl = file[url];
            StartBrowser.driver.Value.Url = testCaseUrl;
        }

        [SetUp]
        public void OpenBrowser()
        {
            //Getting the test Name
            var testname = NUnit.Framework.TestContext.CurrentContext.Test.Name;

            Console.Out.WriteLine("Profile==" + profile + "En");

            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
            NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;

            RemoteSessionSettings capability = new RemoteSessionSettings();
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();

            foreach (string key in caps.AllKeys)
            {
                ltOptions.Add(key, caps[key]);
            }

            foreach (string key in settings.AllKeys)
            {
                ltOptions.Add(key, settings[key]);
            }

            String username = Environment.GetEnvironmentVariable("LT_USERNAME");
            if (username == null)
            {
                username = ConfigurationManager.AppSettings.Get("user");
                ltOptions.Add("user", username);
                Console.Out.WriteLine("Username" + username);
            }

            String accesskey = Environment.GetEnvironmentVariable("LT_ACCESS_KEY");
            if (accesskey == null)
            {
                accesskey = ConfigurationManager.AppSettings.Get("key");
                ltOptions.Add("accessKey", accesskey);
                Console.Out.WriteLine("AccessKey" + accesskey);
            }

            ltOptions.Add("name", testname);
            ltOptions.Add("dedicatedProxy", true);
            string[] fileNames = { "DuskCharger.jpg", "SmallSYPPullSheet.csv", "MagicandPokemon.csv", "Everything50.csv" };
            ltOptions.Add("lambda:userFiles", fileNames);

            capability.AddMetadataSetting("LT:Options", ltOptions);

            Console.WriteLine("LTOPTIONSMATRIX----" + ltOptions);

            Console.WriteLine("CAPABILTYMATRIX----" + capability);

            driver.Value = new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability, TimeSpan.FromSeconds(600));
            var allowsDetection = driver.Value as IAllowsFileDetection;
            if (allowsDetection != null)
            {
                allowsDetection.FileDetector = new LocalFileDetector();
            }

        }
        [SetUp]
        public void BeforeTest()
        {
            parentTest = extent.CreateTest(TestContext.CurrentContext.Test.Name + " on " + environment);

        }

        [TearDown]
        public void ExtentClose()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            try
            {
                // Logs the result to LambdaTest
                ((IJavaScriptExecutor)driver.Value).ExecuteScript("lambda-status=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                driver.Value.Quit();
            }

        }

    }
}