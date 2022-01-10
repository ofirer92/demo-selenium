using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.BaseClass;
using demo.Elements;
using demo.reporter;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.TestClass
{
    [TestFixture]
    class testClass_one : baseclass
    {

        [SetUp]
        public void setup()
        {
            reporter.test.AssignCategory("test class 1");

        }

        // test without POM - page object model
        [Test]
        [Description("test case 1")]
        public void test1_navigte_To_google()
        {

            //navigate to wibsites
            driver.Navigate().GoToUrl("https://www.google.com/");
            
            //wait by time
            Thread.Sleep(1000);

            //send keys to elements
            driver.FindElement(By.CssSelector("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input")).SendKeys("walla");

            //click on element
            driver.FindElement(By.CssSelector("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.FPdoLc.lJ9FBc > center > input.gNO89b")).Click();


            //get list of elements
            IList<IWebElement> list_Of_Elements = driver.FindElements(By.ClassName("LC20lb"));
            string first_item = list_Of_Elements[0].Text;
            
            //driver back activity
            driver.Navigate().Back();
        }







        //test with POM - half way
        [Test]
        [Description("test case 2")]
        public void test2()
        {
            page_one googlePage = new page_one(driver) ;
            driver.Navigate().GoToUrl("https://www.google.com/");
            googlePage.searchBar.SendKeys("walla");
            googlePage.searchBtn.Click();
            string first_item = googlePage.page_results[0].Text;
            driver.Navigate().Back();
        }




        //test with POM
        [Test]
        [Description("test case 3")]
        public void test3()
        {
            page_one googlePage = new page_one(driver) ;
            googlePage.googleSearch("walla");
            string results = googlePage.page_results[0].Text;
            driver.Navigate().Back();
           
        }




        //test with assertion
        [Test]
        [Description("test case 4")]
        [Author("t1")]
        public void test4()
        {
            
            page_one googlePage = new page_one(driver);
            reporter.addScreenshot(driver);
            googlePage.googleSearch("walla");
            int number_of_results = googlePage.number_of_results();
            
            try
            {
                Assert.IsTrue(number_of_results.Equals(8));
            }
            catch (Exception e)
            {
                test.Fail("number is ruslts should be 8 but was only " + number_of_results.ToString());
            }


            try
            {
                Assert.IsTrue(googlePage.voiceBtn.Displayed);
                test.Info("voice btn is avilable");
            }
            catch (Exception e)
            {
                
                test.Fail("cant find Voice search btn");
            }

        }


    }
}
