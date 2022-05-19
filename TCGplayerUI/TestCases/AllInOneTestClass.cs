using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TCGplayerUI.TestCases
{
    [TestFixture("chrome", "101.0", "Windows 10")]
    [TestFixture("firefox", "94.0", "Windows 10")]
    [TestFixture("Safari", "15.0", "MacOS Monterey")]

    [Parallelizable(ParallelScope.All)]
    // [Parallelizable(ParallelScope.Children)]
    public class AllInOneTestClass
    {
        public static string LT_USERNAME = Environment.GetEnvironmentVariable("LT_USERNAME") == null ? "bharatitcgplayer" : Environment.GetEnvironmentVariable("LT_USERNAME");
        public static string LT_ACCESS_KEY = Environment.GetEnvironmentVariable("LT_ACCESS_KEY") == null ? "Eh0bT3rYWA7gDVEUfhfLbueyWk8LS52E9ctLQ5cMGQhzzuIzOa" : Environment.GetEnvironmentVariable("LT_ACCESS_KEY");
        public static bool tunnel = Boolean.Parse(Environment.GetEnvironmentVariable("LT_TUNNEL") == null ? "true" : Environment.GetEnvironmentVariable("LT_TUNNEL"));
        public static string build = Environment.GetEnvironmentVariable("LT_BUILD") == null ? "Test" : Environment.GetEnvironmentVariable("LT_BUILD");
        public static string seleniumUri = "https://hub.lambdatest.com:443/wd/hub";
        public static string sessionId;

        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        private String browser;
        private String version;
        private String os;

        public static AventStack.ExtentReports.ExtentReports _extent;
        public ExtentTest _test;
        public String TC_Name;

        public AllInOneTestClass(String browser, String version, String os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }
        [OneTimeSetUp]
        protected void ExtentStart()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            Console.WriteLine(projectPath.ToString());

            var reportpath = System.IO.Directory.GetParent(@"../../../").FullName
        + Path.DirectorySeparatorChar + "Result"
        + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddd_dd_MMM_yyyy_HH_mm_ss") + ".html";

            //Console.WriteLine(projectPath.ToString());
            //var reportPath = projectPath + "Reports1\\Index.html";
            Console.WriteLine(reportpath);

            var htmlReporter = new ExtentHtmlReporter(reportpath);
            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "Cloud-based Selenium Grid on LambdaTest");
            _extent.AddSystemInfo("Environment", "Test Environment");
            _extent.AddSystemInfo("UserName", "Qadirya");
            htmlReporter.LoadConfig(projectPath + "extent-config.xml");
        }

        [SetUp]
        public void Init()
        {
            //String username = "bharatitcgplayer";
            //String accesskey = "Eh0bT3rYWA7gDVEUfhfLbueyWk8LS52E9ctLQ5cMGQhzzuIzOa";
            //String gridURL = "@hub.lambdatest.com/wd/hub";

            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("build", "Qadirya");
            ltOptions.Add("name", "Qadirya test");
            ltOptions.Add("platformName", os);
            ltOptions.Add("browserName", browser);
            ltOptions.Add("browserVersion", version);
            ltOptions.Add("user", LT_USERNAME);
            ltOptions.Add("accessKey", LT_ACCESS_KEY);
            ltOptions.Add("visual", true);
            RemoteSessionSettings options = new RemoteSessionSettings();
            options.AddMetadataSetting("LT:Options", ltOptions);
            Console.WriteLine(options);
            ltOptions.Add("tunnel", true);

            //Requires a named tunnel.
            //if (tunnel)
            //{
            //    // options.SetCapability("tunnel", tunnel);
            //}
            //if (build != null)
            //{
            //    // capabilities.SetCapability("build", build);
            //}

            driver.Value = new RemoteWebDriver(new Uri(seleniumUri), options);
            Console.Out.WriteLine(driver);

            System.Threading.Thread.Sleep(2000);
        }
        [Test]
        public void TCGTest()
        {
            driver.Value.Url = "https://www.tcgplayer.com/";
            Thread.Sleep(3000);
            IWebElement element = driver.Value.FindElement(By.XPath("//button[@data-testid='search-bar__spyglass']"));
            element.Click();
            Console.WriteLine("Clicking Spy Glass");
            Thread.Sleep(15000);

            String context_name = TestContext.CurrentContext.Test.Name + " on " + browser + " " + version + " " + os;
            TC_Name = context_name;

            _test = _extent.CreateTest(context_name);

        }
        [OneTimeTearDown]
        protected void ExtentClose()
        {
            Console.WriteLine("OneTimeTearDown");
            _extent.Flush();
        }

        [TearDown]
        public void Cleanup()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            var exec_status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus = Status.Pass;
            String screenShotPath, fileName;

            Console.WriteLine("TearDown");

            DateTime time = DateTime.Now;
            fileName = "Screenshot_" + time.ToString("h_mm_ss") + TC_Name + ".png";
            switch (exec_status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    /* The older way of capturing screenshots */
                    screenShotPath = Capture(driver.Value, fileName);
                    /* Capturing Screenshots using built-in methods in ExtentReports 4 */
                    var mediaEntity = CaptureScreenShot(driver.Value, fileName);
                    _test.Log(Status.Fail, "Fail");
                    /* Usage of MediaEntityBuilder for capturing screenshots */
                    _test.Fail("ExtentReport 4 Capture: Test Failed", mediaEntity);
                    /* Usage of traditional approach for capturing screenshots */
                    _test.Log(Status.Fail, "Traditional Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Passed:
                    logstatus = Status.Pass;
                    /* The older way of capturing screenshots */
                    screenShotPath = Capture(driver.Value, fileName);
                    /* Capturing Screenshots using built-in methods in ExtentReports 4 */
                    mediaEntity = CaptureScreenShot(driver.Value, fileName);
                    _test.Log(Status.Pass, "Pass");
                    /* Usage of MediaEntityBuilder for capturing screenshots */
                    _test.Pass("ExtentReport 4 Capture: Test Passed", mediaEntity);
                    /* Usage of traditional approach for capturing screenshots */
                    _test.Log(Status.Pass, "Traditional Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    break;
            }
            _test.Log(logstatus, "Test: " + TC_Name + " Status:" + logstatus + stacktrace);

            try
            {
                ((IJavaScriptExecutor)driver.Value).ExecuteScript("lambda-status=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                driver.Value.Quit();
            }


        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }

        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}