using System;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace OMoney.Integration.Tests
{
    public class BaseIntegrationTest
    {
        //public static IWebDriver Driver = new ChromeDriver();
        public static IWebDriver Driver = new PhantomJSDriver();
        public WebDriverWait Wait;


        [TestFixtureSetUp]
        public void SetupTest()
        {
           Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
           Driver.Manage().Window.Size = new Size(1280, 720);
           // Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 1));
           // Driver.Manage().Window.Maximize();


        }
        [TearDown]
        public void TeardownTest()
        {
            // Driver.Close();         
            Driver.Quit();
        }

    }
}
