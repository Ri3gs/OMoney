using NUnit.Framework;
using OMoney.Integration.Tests.Contexts;
using OMoney.Integration.Tests.Extensions;

namespace OMoney.Integration.Tests.WhenWorkingWithLoginPage
{
    public class AndLoginFormIsEmpty : BaseIntegrationTest
    {
        [Test]
        public void AndFormIsEmptyLoginButtonIsDisabled()
        {
            Driver.
                NavigateToLoginPage().
                CreateLoginPageTestContext().
                ClickOnLoginButton().
                CheckLoginButtonState(ButtonState.Disabled);
        }
    }
}
