using OpenQA.Selenium;

namespace OMoney.Integration.Tests
{
    public class BaseFlowContext
    {
        public IWebDriver WebDriver { get; private set; }

        public BaseFlowContext(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        } 

    }
}
