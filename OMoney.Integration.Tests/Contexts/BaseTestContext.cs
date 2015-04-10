using OpenQA.Selenium;

namespace OMoney.Integration.Tests.Contexts
{
    public class BaseTestContext
    {
        public IWebDriver WebDriver { get; private set; }

        public BaseTestContext(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
