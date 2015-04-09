using NUnit.Framework;
using OMoney.Integration.Tests.Attributes;

namespace OMoney.Integration.Tests.MainApplication.Flows.Bills
{
    [TestFixture]
    public class CreateAccountScenario : BaseIntegrationTest
    {
        [Test]
        [GoldUserAttributes]
        public void CreateOneAccountScenario()
        {
            Driver.NavigateToAccounts()
                .CreateFlow()
                .CreatNewBill()
                .InputName()
                .InputAmount()
                .SubmitBill();

        }
    }
}
