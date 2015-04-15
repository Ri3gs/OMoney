using OpenQA.Selenium;

namespace OMoney.Integration.Tests.Contexts
{
    public enum ButtonState
    {
        Enabled = 0,
        Disabled = 1
    }
    public class BaseTestContext
    {
        public IWebDriver WebDriver { get; private set; }
        public BaseTestContext(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
