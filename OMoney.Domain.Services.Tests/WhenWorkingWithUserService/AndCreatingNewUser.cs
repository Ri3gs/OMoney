using Moq;
using NUnit.Framework;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Validation;
using OMoney.Domain.Services.Notifications.NotificationMessages;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithUserService
{
    [TestFixture]
    public class AndCreatingNewUser
    {
        public UserServiceTestContext TestContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestContext = new UserServiceTestContext();
        }

        [Test]
        public void AndUserIsValid_UserRepositoryCreateMethodShouldBeCalled()
        {
            // Arrange
            // Action
            TestContext.UserService.Create(TestContext.ValidNewUser, TestContext.GoodPass, TestContext.GoodPass);

            // Assert
            TestContext.MockUserRepository.Verify(x => x.Create(It.IsAny<User>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AndUserIsValid_NotificationServiceSendEmailMethodShouldBeCalled()
        {
            // Arrange
            // Action
            TestContext.UserService.Create(TestContext.ValidNewUser, TestContext.GoodPass, TestContext.GoodPass);

            // Assert
            TestContext.MockNotificationService.Verify(x => x.SendConfirmationEmailForNewUser(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void AndUserIsInvalid_DomainEntityValidationExceptionShouldBeThrown()
        {
            // Arrange
            // Action
            // Assert
            Assert.Throws<DomainEntityValidationException>(() => TestContext.UserService.Create(null, string.Empty, string.Empty));
        }
    }
}
