using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace demo.Elements
{
    internal class page_two
    {
        private IWebDriver driver;

        public page_two(IWebDriver driver)
        {
            this.driver = driver;
            
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#inline-popups > div.form-group.user-icon > input")]
        public IWebElement usernameField { get; set; }

        
        [FindsBy(How = How.CssSelector, Using = "#inline-popups > div.form-group.lock-icon.mb-0 > input")]
        public IWebElement passwordField { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "#inline-popups > button")]
        public IWebElement loginBtn { get; set; }




        public void login(string username, string password)
        {
            Help H = new Help();
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            acceptTerms();
            loginBtn.Click();
            H.MainloadingWait(driver);
        }

        public void acceptTerms()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("document.querySelector('.acceptTerms').click()");
        }
    }
}
