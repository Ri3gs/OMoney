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
            var result = TestContext.CreateNewUserValidator.Validate(user, TestContext.GoodPass, TestContext.GoodPass);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void AndUserIsNull()
        {
            // Arrange
            // Action
            var result = TestContext.CreateNewUserValidator.Validate(null, string.Empty, string.Empty);

            // Assert
            StringAssert.IsMatch("User is NULL.", result.First());
        }

        [Test]
        public void AndEmailIsEmpty()
        {
            // Arrange
            var user = new User {Email = string.Empty, IsActive = true};

            // Action
            var result = TestContext.CreateNewUserValidator.Validate(user, TestContext.GoodPass, TestContext.GoodPass);

            // Assert
            StringAssert.IsMatch("Email is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordIsEmpty()
        {
            // Arrange
            // Action
            var result = TestContext.CreateNewUserValidator.Validate(TestContext.ValidUser, string.Empty, TestContext.GoodPass);

            // Assert
            StringAssert.IsMatch("Password is EMPTY.", result.First());
        }

        [Test]
        public void AndConfirmPasswordIsEmpty()
        {
            // Arrange
            // Action
            var result = TestContext.CreateNewUserValidator.Validate(TestContext.ValidUser, TestContext.GoodPass, string.Empty);

            // Assert
            StringAssert.IsMatch("Password Confirm is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordAndConfirmPasswordDoesNotMatch()
        {
            // Arrange
            // Action
            var result = TestContext.CreateNewUserValidator.Validate(TestContext.ValidUser, TestContext.GoodPass, TestContext.BadPass);

            // Assert
            StringAssert.IsMatch("Password and Confirm Password does not match.", result.First());
        }
    }
}