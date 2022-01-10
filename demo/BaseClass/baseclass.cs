using System.Drawing;
using System.Windows.Forms;
using AventStack.ExtentReports;
using demo.Helpers;
using demo.reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demo.BaseClass
{
     class baseclass
    {
        public static IWebDriver driver;
        public ExtentTest test;

        //parameters
        public string userName = "setup5.4.2";
        public string Password = "1234";



        //Links QA\Alpha\GA
        #region
        private static string Alpha = "https://afimilkbackupwebalpha.z6.web.core.windows.net/#/home";
        private static string QA = "https://afimilkbackupwebqa.z6.web.core.windows.net/#/login";
        private static string GA = "https://afimilkbackupweb.z6.web.core.windows.net/#/login";
        private static string dev = "https://afimilkbackupwebdev.z6.web.core.windows.net/#/login";
        #endregion


        //      Selected environment
        string selected_Environment = QA;


        public string reportPath = @"C:\Demo testing\";
        public Reporter reporter = new Reporter();


        [OneTimeSetUp]
        public void OneTimesetup()
        {

            Helpers.Help c = new Helpers.Help();

            if (Reporter.extent == null)
            {
                driver = new ChromeDriver();


                Rectangle resolution = Screen.PrimaryScreen.Bounds;
                Reporter.extent = new ExtentReports();
                Reporter.extent.AddSystemInfo("Browser", "Chrome");
                Reporter.extent.AddSystemInfo("Browser Version ", "96");
                Reporter.extent.AddSystemInfo("Resolution", resolution.ToString());
                Reporter.extent.AddSystemInfo("Resolution", resolution.ToString());


                reporter.setPath(reportPath);


                driver.Navigate().GoToUrl(selected_Environment);

                driver.Close();


            }
        }

        //לפני כל טסט
        [SetUp]
        public void openAndRun()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(QA);
            driver.Manage().Window.Maximize();

            test = reporter.startReporting();
        }



        //אחרי כל טסט
        [TearDown]
        public void close()
        {
            reporter.testReporting(driver);
            driver.Quit();
        }


        //אחרי כל הטסטים
        [OneTimeTearDown]
        public void thisIsTheEnd()
        {
            Reporter.extent.Flush();

        }
    }
}
