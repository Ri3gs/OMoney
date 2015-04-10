using NUnit.Framework;
using OMoney.Integration.Tests.Extensions;

namespace OMoney.Integration.Tests.WhenWorkingWithLoginPage
{
    [TestFixture]
    public class AndLoginDataIsCorrect : BaseIntegrationTest
    {
        [Test]
        public void AndLoginButtonIsDisabled()
        {
            Driver.NavigateToLoginPage();
        }
    }
}
