using OpenQA.Selenium;

namespace OMoney.Integration.Tests.Contexts
{
    public class LoginPageTestContext : BaseTestContext
    {
        public LoginPageTestContext(IWebDriver webDriver) : base(webDriver)
        {
        }

        public LoginPageTestContext ClickOnLoginButton()
        {
            return this;
        }

        public LoginPageTestContext CheckLoginButtonState(ButtonState buttonState)
        {
            return this;
        }
    }
}
