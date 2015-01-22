using System.Linq;
using NUnit.Framework;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Validation.Users;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithValidators
{
    [TestFixture]
    public class AndUsingCreateNewUserValidator
    {
        public ValidatorsTestContext TestContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestContext = new ValidatorsTestContext();
        }

        [Test]
        public void AndUserIsValid()
        {
            // Arrange
            var user = TestContext.ValidUser;

            // Action
            var result = TestContext.CreateNewUserValidator.Validate(user);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void AndUserIsNull()
        {
            // Arrange
            // Action
            var result = TestContext.CreateNewUserValidator.Validate(null);

            // Assert
            StringAssert.IsMatch("User is NULL.", result.First());
        }

        [Test]
        public void AndEmailIsEmpty()
        {
            // Arrange
            var user = new User {Email = string.Empty, Password = "1234qwer", ConfirmPassword = "1234qwer"};

            // Action
            var result = TestContext.CreateNewUserValidator.Validate(user);

            // Assert
            StringAssert.IsMatch("Email is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordIsEmpty()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = string.Empty, ConfirmPassword = "1234qwer" };

            // Action
            var result = TestContext.CreateNewUserValidator.Validate(user);

            // Assert
            StringAssert.IsMatch("Password is EMPTY.", result.First());
        }

        [Test]
        public void AndConfirmPasswordIsEmpty()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = "1234qwer", ConfirmPassword = string.Empty };

            // Action
            var result = TestContext.CreateNewUserValidator.Validate(user);

            // Assert
            StringAssert.IsMatch("Password Confirm is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordAndConfirmPasswordDoesNotMatch()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = "1234qwer", ConfirmPassword = "1234qwert" };

            // Action
            var result = TestContext.CreateNewUserValidator.Validate(user);

            // Assert
            StringAssert.IsMatch("Password and Confirm Password does not match.", result.First());
        }
    }
}