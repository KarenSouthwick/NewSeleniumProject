using System;
using excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace NewSeleniumProject
{
    class BlogSpot
    {
        private string email;
        private string pass;

        [Test]
        public void Test()
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://qa-platform.authenticateis.com/Account/Logon");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                excel.Application x1app = new excel.Application();
                excel.Workbook x1workbook = x1app.Workbooks.Open(@"C:\temp\vince.xlsx");
                excel._Worksheet x1worksheet = x1workbook.Sheets[1];
                excel.Range x1range = x1worksheet.UsedRange;

                int count = x1range.Rows.Count;
                for (int i = 1; i <= count; i++)

                {
                    string email = (x1range.Cells[i, 1] as excel.Range).Value;
                    string pass = (x1range.Cells[i, 2] as excel.Range).Value;

                    driver.FindElement(By.Id("UserName")).SendKeys(email);
                    driver.FindElement(By.Id("Password")).SendKeys(pass);
                    driver.FindElement(By.Id("do-submit")).Click();
                    driver.FindElement(By.CssSelector(".lock")).Click();
                }

                driver.Quit();
                x1app.Quit();
            }
            catch (Exception ex)
            {

            }

        }

    }
}
