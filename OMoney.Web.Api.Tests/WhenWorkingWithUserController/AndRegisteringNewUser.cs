using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using NUnit.Framework;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Validation;
using OMoney.Web.Api.Models;

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
