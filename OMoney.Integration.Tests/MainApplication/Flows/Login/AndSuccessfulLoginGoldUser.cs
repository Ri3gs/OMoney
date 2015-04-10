using NUnit.Framework;
using OMoney.Integration.Tests.Attributes;

namespace OMoney.Integration.Tests.MainApplication.Flows.Login
{
    [TestFixture]
    public class AndSuccessfulLoginGoldUser : BaseIntegrationTest
    {
        [Test]
        [GoldUserAttributes]
        public void LoginnigGoldUser()
        {
            //Driver.NavigateToLogin()
            //    .CreateFlow();
            //.EditeEmailFieldForNewUserOnHomeLogin()
            //.EditePasslFieldForNewUserOnHomeLogin()
            //.EditeConfirmPassFieldForNewUserOnHomeLogin()
            //.PressSignUpButtonOnHomeLogin();

            //.PressArchiveButton()
            //.PressTodayButton()
            //.PressNextWeekButton();
        } 
    }
}
