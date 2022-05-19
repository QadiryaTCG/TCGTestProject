using AventStack.ExtentReports.Reporter;
using Framework.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;
namespace TCGplayerUI.TestSetUp
{
    [SetUpFixture]
    public static class SetUpClass
    {
        public static AventStack.ExtentReports.ExtentReports extent;
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
      + Path.DirectorySeparatorChar + "Result"
      + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddd_dd_MMM_yyyy_HH_mm_ss") + ".html";
        //static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
        //         + Path.DirectorySeparatorChar + "Result"
        //         + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddd_dd_MMM_yyyy_HH_mm_ss") + ".html";
        static string indexpath = System.IO.Directory.GetParent(@"../../../").FullName
           + Path.DirectorySeparatorChar + "Result"
           + Path.DirectorySeparatorChar + "index.html";
        [OneTimeSetUp]
        public static void ReportInit()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            string env = ConfigReaders.LoadConfig();
            var htmlReporter = new ExtentHtmlReporter(reportpath);
            extent.AttachReporter(htmlreport);
            extent.AddSystemInfo("Host Name", "QE Automation");
            extent.AddSystemInfo("Environment", env);
            htmlReporter.LoadConfig(projectPath + "extent-config.xml");
        }
        [OneTimeTearDown]
        public static void Reportgenerate()
        {
            extent.Flush();
            System.IO.File.Copy(indexpath, reportpath);
        }
    }
}