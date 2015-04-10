using System;
using OMoney.Integration.Tests.Configuration;
using OMoney.Integration.Tests.MainApplication.Flows;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OMoney.Integration.Tests.MainApplication
{
    public static class MainApplicationExtensions
    {
        public static MainApplicationFlowContext CreateFlow(this IWebDriver webDriver)
        {
            return new MainApplicationFlowContext(webDriver);
        }
    }
}
