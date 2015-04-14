using OMoney.Integration.Tests.Extensions;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.WhenWorkingWithLoginPage
{
    public static class SearchContextLoginPageExtensions
    {
        public static IWebElement FindEmailFieald(this ISearchContext elem)
        {
            return elem.WaitForElement(By.Id("Email"));
        }
        public static IWebElement FindPasswordFieald(this ISearchContext elem)
        {
            return elem.WaitForElement(By.Id("Password"));
        }

        public static IWebElement FindSubmitButton(this ISearchContext elem)
        {
            return elem.FindButtonByText("submit");
        }
    }
}
