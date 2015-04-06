using NUnit.Framework;
using OMoney.Integration.Tests.Attributes;

namespace OMoney.Integration.Tests.MainApplication.Flows.Home
{
    [TestFixture]
   public class AndSmokeTestingPage : BaseIntegrationTest
    {
        [Test]
        [BaseAttributes]
        public void TestingPageObject()
        {
            Driver.NavigateToSignUP()
                .CreateFlow()
                .EditeEmailFieldForNewUserOnHomeLogin()
                .EditePasslFieldForNewUserOnHomeLogin()
                .EditeConfirmPassFieldForNewUserOnHomeLogin()
                .PressSignUpButtonOnHomeLogin();

            //.PressArchiveButton()
            //.PressTodayButton()
            //.PressNextWeekButton();
        } 
    }
}
