using System.Web.Http.Results;
using NUnit.Framework;

namespace OMoney.Web.Api.Tests.WhenWorkingWithUserController
{
    [TestFixture]
    public class AndRegisteringNewUser
    {
        public UserControllerTestContext TestContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestContext = new UserControllerTestContext();
        }

        [Test]
        public void AndUserIsValid()
        {
            // Arrange
            // Action
            var actionResult = TestContext.UserController.Signup(TestContext.ValidUser);
            // Assert
            Assert.IsInstanceOf<OkResult>(actionResult);
        }

        [Test]
        public void AndUserIsInvalid()
        {
            // Arrange
            // Action
            // Assert
            var actionResult = TestContext.UserController.Signup(TestContext.InvalidUser);
            Assert.IsInstanceOf<InvalidModelStateResult>(actionResult);
        }
    }
}
