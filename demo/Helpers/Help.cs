using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace demo.Helpers
{
    class Help
    {
        public void MainloadingWait(IWebDriver driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementExists((By.ClassName("sh-download-icon"))));
            Thread.Sleep(500);
        }
    }
}
