using OMoney.Integration.Tests.Contexts;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.Extensions
{
    public static class CommonExtensions
    {
        public static LoginPageTestContext CreateLoginPageTestContext(this IWebDriver webDriver)
        {
            return new LoginPageTestContext(webDriver);
        }
    }
}
