using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSeleniumProject
{
    public class MyFirstTest
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void DoMyFirstTest()
        { driver.Navigate().GoToUrl("http://www.swtestacademy.com");
            Assert.AreEqual(expected: "SW Test Academy | Software Testing Academy", actual: driver.Title);
            driver.Close();
            driver.Quit();
        }
    }
}
