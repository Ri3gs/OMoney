using System;
using System.Linq;
using NUnit.Framework;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithValidators
{
    [TestFixture]
    public class AndUsingUpdateUserValidator
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
            var user = new User { Name = "ri3gs", Email = "test@mail.com", Password = "qwerty", ConfirmPassword = "qwerty", IsActive = true };

            // Action
            var result = TestContext.UpdateUserValidator.Validate(user);

            // Arrange
            Assert.IsEmpty(result);
        }


        //[Test]
        //public void AndUserDoesNotExist()
        //{
        //    // Arrange
        //    var user = new User { Name = "ri3gs", Email = "test@mail.com", Password = "qwerty", ConfirmPassword = "qwerty", IsActive = true };

        //    // Action
        //    var result = TestContext.UpdateUserValidator.Validate(user);

        //    // Arrange
        //    Assert.AreEqual("User does not exist.", result.First());
        //}

        [Test]
        public void AndUserIsNull()
        {
            // Arrange
            // Action
            var result = TestContext.UpdateUserValidator.Validate(null);

            // Arrange
            Assert.AreEqual("User is NULL.", result.First());
        }

        [Test]
        public void AndEmailIsEmpty()
        {
            // Arrange
            var user = new User { Email = string.Empty, Password = "1234qwer", ConfirmPassword = "1234qwer" };

            // Action
            var result = TestContext.UpdateUserValidator.Validate(user);

            // Arrange
            StringAssert.IsMatch("Email is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordIsEmpty()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = string.Empty, ConfirmPassword = "1234qwer" };

            // Action
            var result = TestContext.UpdateUserValidator.Validate(user);

            // Arrange
            StringAssert.IsMatch("Password is EMPTY.", result.First());
        }

        [Test]
        public void AndConfirmPasswordIsEmpty()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = "1234qwer", ConfirmPassword = string.Empty };

            // Action
            var result = TestContext.UpdateUserValidator.Validate(user);

            // Arrange
            StringAssert.IsMatch("Password Confirm is EMPTY.", result.First());
        }

        [Test]
        public void AndPasswordAndConfirmPasswordDoesNotMatch()
        {
            // Arrange
            var user = new User { Email = "test@email.com", Password = "1234qwer", ConfirmPassword = "1234qwert" };

            // Action
            var result = TestContext.UpdateUserValidator.Validate(user);

            // Arrange
            StringAssert.IsMatch("Password and Confirm Password does not match.", result.First());
        }
    }
}
