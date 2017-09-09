using System;
using System.Threading;
using OMoney.Integration.Tests.Configuration;
using OMoney.Integration.Tests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OMoney.Integration.Tests.Attributes
{
    class GoldUserAttributes : BaseAttributes
    {
        public override void Login(IWebDriver driver)
        {
            Thread.Sleep(1000);
            driver.NavigateToLoginPage();
            driver.WaitForElement(By.XPath("//*[@id='Email']")).Clear();
            driver.WaitForElement(By.XPath("//*[@id='Email']")).SendKeys("gold@mail.com");
            driver.WaitForElement(By.XPath("//*[@id='Password']")).Clear();
            driver.WaitForElement(By.XPath("//*[@id='Password']")).SendKeys("golddemo");
            Thread.Sleep(1000);
            driver.WaitForElement(By.XPath("//button[@type='submit']")).Click();
           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url == Config.MainApplicationBaseUrl + "/#/profile");
        }
        
    }
}
