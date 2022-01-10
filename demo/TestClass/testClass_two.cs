using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.BaseClass;
using demo.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.TestClass
{
    [TestFixture]
    internal class testClass_two : baseclass
    {
        [SetUp]
        public void setup()
        {
            reporter.test.AssignCategory("test class 2");
            page_one googlePage = new page_one(driver);
            
        }

        [Test]
        [Description("test case 1")]
        public void test1_navigte_To_google()
        {
            page_two backup = new page_two(driver);
            backup.login(userName, Password);

            reporter.addScreenshot(driver);

        }
    }
}
