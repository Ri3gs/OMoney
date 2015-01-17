using Moq;
using OMoney.Data.Users;
using OMoney.Domain.Entities.Entities;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Users;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithUserService
{
    public class UserServiceTestContext
    {
        public Mock<IUserRepository> MockUserRepository { get; set; }
        public Mock<INotificationService> MockNotificationService { get; set; }
        public UserService UserService { get; set; }

        public User ValidUser {
            get { return new User {Email = "test@email.com", Password = "1234qwer", ConfirmPassword = "1234qwer"}; }
        }

        public UserServiceTestContext()
        {
            MockUserRepository = new Mock<IUserRepository>();
            MockNotificationService = new Mock<INotificationService>();

            UserService = new UserService(MockUserRepository.Object, MockNotificationService.Object);
        }
    }
}
