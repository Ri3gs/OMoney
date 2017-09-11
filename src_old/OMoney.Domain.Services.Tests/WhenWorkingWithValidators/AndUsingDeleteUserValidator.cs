using System;
using System.Linq;
using NUnit.Framework;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithValidators
{
    [TestFixture]
    public class AndUsingDeleteUserValidator
    {
        public ValidatorsTestContext TestContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestContext = new ValidatorsTestContext();
        }

        [Test]
        public void AndUserDoesNotExist()
        {
            // Arrange
            var user = TestContext.PhantomUser;

            // Action
            var result = TestContext.DeleteUserValidator.Validate(user);

            // Arrange
            Assert.AreEqual("User does not exist.", result.First());
        }

        [Test]
        public void AndUserIsNull()
        {
            // Arrange
            // Action
            var result = TestContext.DeleteUserValidator.Validate(null);

            // Arrange
            Assert.AreEqual("User is NULL.", result.First());
        }

        [Test]
        public void AndUserIsValid()
        {
            // Arrange
            var user = TestContext.ValidUser;

            // Action
            var result = TestContext.DeleteUserValidator.Validate(user);

            // Arrange
            Assert.IsEmpty(result);
        }
    }
}
