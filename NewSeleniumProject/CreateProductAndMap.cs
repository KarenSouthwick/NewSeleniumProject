using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NewSeleniumProject
{
    [TestFixture]
    public class Test1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private string value;
        private string value2;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(chromeDriverDirectory: @"C:\Libraries");
            baseURL = "https://dev-platform.authenticateis.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void The1Test()
        {
            // open | /Account/Logon | 
            driver.Navigate().GoToUrl(baseURL + "/Account/Logon");
            // type | id=UserName | angelgaltrey
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("angelgaltrey");
            // type | id=Password | Aramark22
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            // click | id=do-submit | 
            driver.FindElement(By.Id("do-submit")).Click();
            // click | link=My Products | 
            driver.FindElement(By.LinkText("My Products")).Click();
            // click | link=Product Catalogue | 
            driver.FindElement(By.LinkText("Product Catalogue")).Click();
            // click | css=#do-categories .categoryBox:eq(3) > a | 
            driver.FindElement(By.XPath("//div[4]/div/div/a/div/div")).Click();
            // click | link=create new | 
            driver.FindElement(By.LinkText("create new")).Click();
            // store | javascript{Math.floor(Math.random()*1111)+ 100} | value
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            // type | id=ProductLine_Name | ${value}
            driver.FindElement(By.Id("ProductLine_Name")).Clear();
            driver.FindElement(By.Id("ProductLine_Name")).SendKeys(value);
            // echo | ${value} | 
            Console.WriteLine(value);
            // store | javascript{Math.floor(Math.random()*1111)+ 100} | value2
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            // type | id=ProductLine_ReferenceCode | ${value2}
            driver.FindElement(By.Id("ProductLine_ReferenceCode")).Clear();
            driver.FindElement(By.Id("ProductLine_ReferenceCode")).SendKeys(value2);
            // echo | ${value2} | 
            Console.WriteLine(value2);
            // verifyElementPresent | css=.selectize-input | 
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector(".selectize-input")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // sendKeys | xpath=(//input[@type='text'])[5] | Cranswick Delico${KEY_ENTER}
            driver.FindElement(By.XPath("(//input[@type='text'])[5]")).SendKeys("Cranswick Delico" + Keys.Enter);
            // selectWindow | null | 
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            // click | css=button.buttonHalf.success | 
            driver.FindElement(By.CssSelector("button.buttonHalf.success")).Click();
            // click | link=map product | 
            driver.FindElement(By.LinkText("map product")).Click();
            // type | name=ProductLinkSearchRequests[0].Company.Name | AAK (UK) Ltd
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].Company.Name")).Clear();
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].Company.Name")).SendKeys("AAK (UK) Ltd");
            // click | id=AAK (UK) Ltd | tabindex='-1'
            driver.FindElement(By.Id("AAK (UK) Ltd")).Click();
            // selectWindow | null | 
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            // type | name=ProductLinkSearchRequests[0].ProductName | ${value}
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].ProductName")).Clear();
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].ProductName")).SendKeys(value);
            // type | name=ProductLinkSearchRequests[0].ProductReference | ${value2}
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].ProductReference")).Clear();
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].ProductReference")).SendKeys(value2);
            // click | id=do-sendRequests | 
            driver.FindElement(By.Id("do-sendRequests")).Click();
            // selectWindow | null | 
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            // click | css=a.lock | 
            driver.FindElement(By.CssSelector("a.lock")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
