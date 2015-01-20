using Moq;
using NUnit.Framework;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Validation;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithUserService
{
    [TestFixture]
    public class AndUpdatingUser
    {
        public UserServiceTestContext TestContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestContext = new UserServiceTestContext();
        }

        [Test]
        public void AndUserIsValid_UserRepositoryUpdateMethodShouldBeCalled()
        {
            // Arrange
            // Action
            TestContext.UserService.Update(TestContext.ValidUser);

            // Assert
            TestContext.MockUserRepository.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void AndUserIsInvalid_DomainEntityValidationExceptionShouldBeThrown()
        {
            // Arrange
            // Action
            // Assert
            Assert.Throws<DomainEntityValidationException>(() => TestContext.UserService.Update(null));
        }

        //[Test]
        //public void AndUserDoesNotExist_DomainEntityValidationExceptionShouldBeThrown()
        //{
        //    // Arrange
        //    // Action
        //    // Assert
        //    Assert.Throws<DomainEntityValidationException>(() => TestContext.UserService.Update(TestContext.ValidUser));
        //}
    }
}
