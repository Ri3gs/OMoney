using System.Net.Http;
using System.Web.Http;
using Moq;
using OMoney.Data.Repositories;
using OMoney.Data.Repositories.Users;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Users;
using OMoney.Web.Api.Controllers;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Tests.WhenWorkingWithUserController
{
    public class UserControllerTestContext
    {
        public Mock<IUserRepository> MockUserRepository { get; set; }
        public Mock<INotificationService> MockNotificationService { get; set; }
        public UserService UserService { get; set; }
        public UserController UserController { get; set; }

        public UserViewModel ValidUser
        {
            get
            {
                return new UserViewModel {Email = "test@email.com", Password = "SuperPass", ConfirmPassword = "SuperPass"};
            }
        }

        public UserViewModel InvalidUser {
            get
            {
                return new UserViewModel {Email = "fail", Password = "fail", ConfirmPassword = "liaf"};
            }
        }

        public UserControllerTestContext()
        {
            MockUserRepository = new Mock<IUserRepository>();
            MockNotificationService = new Mock<INotificationService>();

            UserService = new UserService(MockUserRepository.Object, MockNotificationService.Object);
            UserController = new UserController(UserService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }


    }
}
