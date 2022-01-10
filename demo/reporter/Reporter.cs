using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace demo.reporter
{
    class Reporter
    {

        public static ExtentReports extent;
        public ExtentTest test;
        private IWebDriver driver;
        public static int scrennshotNumber = 0;
        public string Fullscreenshotpath;
        private static string screenshotpath;

        public string disc;


        internal ExtentTest startReporting()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Properties.Get("Description").ToString());
            disc = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
            return test;

        }

        internal void testReporting(IWebDriver driver)
        {
            this.driver = driver;
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    test.Log(logstatus, "Test ended with error " + test.AddScreenCaptureFromPath(screenShot(disc)));
                    break;
                
                default:
                    logstatus = Status.Pass;
                    test.Log(logstatus, "Pass" + test.AddScreenCaptureFromPath(screenShot(disc)));
                    break;
            }
        }
        public string screenShot(string testDisc)
        {

            scrennshotNumber++;
            Fullscreenshotpath = screenshotpath + scrennshotNumber.ToString() + ".png";

            if (!Directory.Exists(screenshotpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(screenshotpath);
            }

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Fullscreenshotpath, ScreenshotImageFormat.Png);
            return Fullscreenshotpath;
        }
        public void addScreenshot(IWebDriver driver)
        {
            this.driver = driver;
            Status logstatus;
            logstatus = Status.Info;
            test.Log(logstatus, "Pass" + test.AddScreenCaptureFromPath(screenShot(disc)));


        }
        internal void setPath(string path)
        {
            var spark = new ExtentSparkReporter(path   + @"\Report.html");
            screenshotpath = path + @"\Screenshots\";
            extent.AttachReporter(spark);
        }


    }
}
