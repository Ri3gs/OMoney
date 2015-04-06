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
        public static IWebDriver NavigateToHome(this IWebDriver webDriver)
        {
            return webDriver.NavigateTo("/#/home");
        }
        public static IWebDriver NavigateToLogin(this IWebDriver webDriver)
        {
            return webDriver.NavigateTo("/#/login");
        }
        public static IWebDriver NavigateToSignUP(this IWebDriver webDriver)
        {
            return webDriver.NavigateTo("/#/home#signup");
        }
        //public static IWebDriver NavigateToNextWeek(this IWebDriver webDriver)
        //{
        //    return webDriver.NavigateTo("/#/nextweek");
        //}
        private static IWebDriver NavigateTo(this IWebDriver webDriver, string route)
        {
            string navigationUrl = Config.MainApplicationBaseUrl + route;
            webDriver.Navigate().GoToUrl(navigationUrl);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.Url == navigationUrl);

            return webDriver;
        }
    }
}
