using System.Linq;
using NUnit.Framework;
using OMoney.Domain.Core.Validation.Users;
using OMoney.Domain.Entities.Entities;

namespace OMoney.Domain.Core.Tests.WhenWorkingWithValidators
{
    [TestFixture]
    public class AndUsingCreateNewUserValidator
    {
        public CreateNewUserValidator CreateNewUserValidator { get; set; }

        [SetUp]
        public void SetUp()
        {
            CreateNewUserValidator = new CreateNewUserValidator();
        }

        [Test]
        public void AndUserIsValid()
        {
            // Arrange
            var user = new User {Email = "test@email.com", Password = "1234qwer", ConfirmPassword = "1234qwer"};

            // Action
            var result = CreateNewUserValidator.Validate(user);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void AndUserIsNull()
        {
            // Arrange
            // Action
            var result = CreateNewUserValidator.Validate(null);

            // Arrange
            StringAssert.IsMatch("User is NULL.", result.First());
        }

        [Test]
        public void AndEmailIsEmpty()
        {
            // Arrange
            var user = new User {Email = string.Empty, Password = "1234qwer", ConfirmPassword = "1234qwer"};

            // Action
            var result = CreateNewUserValidator.Validate(user);

            // Arrange
            StringAssert.IsMatch("Email is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordIsEmpty()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = string.Empty, ConfirmPassword = "1234qwer" };

            // Action
            var result = CreateNewUserValidator.Validate(user);

            // Arrange
            StringAssert.IsMatch("Password is EMPTY.", result.First());
        }

        [Test]
        public void AndConfirmPasswordIsEmpty()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = "1234qwer", ConfirmPassword = string.Empty };

            // Action
            var result = CreateNewUserValidator.Validate(user);

            // Arrange
            StringAssert.IsMatch("Password Confirm is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordAndConfirmPasswordDoesNotMatch()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = "1234qwer", ConfirmPassword = "1234qwert" };

            // Action
            var result = CreateNewUserValidator.Validate(user);

            // Arrange
            StringAssert.IsMatch("Password and Confirm Password does not match.", result.First());
        }
    }
}