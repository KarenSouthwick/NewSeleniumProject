using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NewSeleniumProject
{
    [TestFixture]
    public class Colinshawproducts
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
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
        public void TheColinshawproductsTest()
        {
            // open | /Account/Logon | 
            driver.Navigate().GoToUrl(baseURL + "/Account/Logon");
            // type | id=UserName | colinshaw
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("colinshaw");
            // type | id=Password | Aramark22
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            // click | id=do-submit | 
            driver.FindElement(By.Id("do-submit")).Click();
            // click | id=do-submitPrimary | 
            driver.FindElement(By.Id("do-submitPrimary")).Click();
            // click | //div[@id='do-hoverBoxes']/div[3]/div/div[2]/div/a/div | 
            driver.FindElement(By.XPath("//div[@id='do-hoverBoxes']/div[3]/div/div[2]/div/a/div")).Click();
            // click | css=div.imageHolder | 
            driver.FindElement(By.CssSelector("div.imageHolder")).Click();
            // click | link=company details | 
            driver.FindElement(By.LinkText("company details")).Click();
            // click | link=view all received products | 
            driver.FindElement(By.LinkText("view all received products")).Click();
            // assertText | css=span > i | salmon fishcakes - M144342
            Assert.AreEqual("salmon fishcakes - M144342", driver.FindElement(By.CssSelector("span > i")).Text);
            // click | link=direct products | 
            driver.FindElement(By.LinkText("direct products")).Click();
            // verifyText | css=p.strong | 2 Sisters Food Group
            try
            {
                Assert.AreEqual("2 Sisters Food Group", driver.FindElement(By.CssSelector("p.strong")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
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
