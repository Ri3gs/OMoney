using System;
using OMoney.Integration.Tests.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OMoney.Integration.Tests.Extensions
{
    public static class NavigationExtensions
    {
        public static IWebDriver NavigateToHome(this IWebDriver webDriver)
        {
            return webDriver.NavigateTo("/#/home");
        }
        public static IWebDriver NavigateToLoginPage(this IWebDriver webDriver)
        {
            return webDriver.NavigateTo("/#/login");
        }
        public static IWebDriver NavigateToSignUp(this IWebDriver webDriver)
        {
            return webDriver.NavigateTo("/#/home#signup");
        }
        public static IWebDriver NavigateToAccounts(this IWebDriver webDriver)
        {
            return webDriver.NavigateTo("/#/accounts");
        }
        private static IWebDriver NavigateTo(this IWebDriver webDriver, string route)
        {
            string navigationUrl = Config.MainApplicationBaseUrl + route;
            webDriver.Navigate().GoToUrl(navigationUrl);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url == navigationUrl);

            return webDriver;
        }
    }
}
