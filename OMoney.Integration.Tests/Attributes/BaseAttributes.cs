using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OMoney.Integration.Tests.Extensions;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.Attributes
{
    abstract class BaseAttributes : Attribute, ITestAction
    {
        public void AfterTest(ITest test)
        {
            BaseIntegrationTest baseTest = test.Fixture as BaseIntegrationTest;
            LogOut(BaseIntegrationTest.Driver);
        }

        public void BeforeTest(ITest test)
        {
            BaseIntegrationTest baseTest = test.Fixture as BaseIntegrationTest;
            Login(BaseIntegrationTest.Driver);

        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
        public abstract void Login(IWebDriver driver);

        public virtual void LogOut(IWebDriver driver)
        {
            driver.WaitForElement(By.XPath("/html/body/div/div[1]/div/nav/ul/li[4]/a")).ForceClick();
        }
    }
}
