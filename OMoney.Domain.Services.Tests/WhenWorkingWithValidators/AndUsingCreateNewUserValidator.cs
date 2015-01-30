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
            TestContext.SetPasswords(TestContext.GoodPass, TestContext.GoodPass);

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
            var user = new User {Email = string.Empty, IsActive = true};

            // Action
            var result = TestContext.CreateNewUserValidator.Validate(user);

            // Assert
            StringAssert.IsMatch("Email is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordIsEmpty()
        {
            // Arrange
            TestContext.SetPasswords(string.Empty, TestContext.GoodPass);
            // Action
            var result = TestContext.CreateNewUserValidator.Validate(TestContext.ValidUser);

            // Assert
            StringAssert.IsMatch("Password is EMPTY.", result.First());
        }

        [Test]
        public void AndConfirmPasswordIsEmpty()
        {
            // Arrange
            TestContext.SetPasswords(TestContext.GoodPass, string.Empty);
            // Action
            var result = TestContext.CreateNewUserValidator.Validate(TestContext.ValidUser);

            // Assert
            StringAssert.IsMatch("Password Confirm is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordAndConfirmPasswordDoesNotMatch()
        {
            // Arrange
            TestContext.SetPasswords(TestContext.GoodPass, TestContext.BadPass);
            // Action
            var result = TestContext.CreateNewUserValidator.Validate(TestContext.ValidUser);

            // Assert
            StringAssert.IsMatch("Password and Confirm Password does not match.", result.First());
        }
    }
}