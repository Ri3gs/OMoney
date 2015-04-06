using System;
using System.Drawing;
using NUnit.Framework;
using OMoney.Data.Context;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OMoney.Integration.Tests
{
    public class BaseIntegrationTest
    {
        public static IWebDriver Driver = new ChromeDriver();
        //public AuthContext _authContext;
        public WebDriverWait _wait;


        [TestFixtureSetUp]
        public void SetupTest()
        {
            //_authContext = new AuthContext();
            //var assignments = _authContext.AspNetUsers;
            //_authContext.AspNetUsers.RemoveRange(assignments);
            //_authContext.SaveChanges();
            Driver.Manage().Window.Size = new Size(1280, 720);
            _wait = new WebDriverWait(Driver, TimeSpan.FromHours(5));
            // Driver.Manage().Window.Maximize();


        }
        [TearDown]
        public void TeardownTest()
        {
            // Driver.Close();         
            //Driver.Quit();
            //_authContext.Dispose();
        }

    }
}
