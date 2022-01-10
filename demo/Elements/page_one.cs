using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace demo.Elements
{
    internal class page_one
    {
        private IWebDriver driver;

        private string googleUtl = "https://www.google.com";

        public page_one(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input")]
        public IWebElement searchBar { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.FPdoLc.lJ9FBc > center > input.gNO89b")]
        public IWebElement searchBtn { get; set; }
             
        [FindsBy(How = How.CssSelector, Using = "#tsf > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.dRYYxd > div.XDyW0e")]
        public IWebElement voiceBtn { get; set; }
             
        
        [FindsBy(How = How.ClassName, Using = "LC20lb")]
        public IList<IWebElement> page_results { get; set; }

        public void googleSearch(string val)
        {
            driver.Navigate().GoToUrl(googleUtl);
            searchBar.SendKeys(val);
            searchBtn.Click();
        }

        public int number_of_results()
        {
            return page_results.Count;
        }
    }
}
