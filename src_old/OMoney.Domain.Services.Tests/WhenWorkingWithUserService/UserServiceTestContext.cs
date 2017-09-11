using Moq;
using OMoney.Data.Repositories;
using OMoney.Data.Repositories.Users;
using OMoney.Domain.Core.Entities;
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
            get { return new User {Email = "test@email.com"}; }
        }

        public User PhantomUser
        {
            get { return new User {Email = "phantom@gmail.com"}; }
        }

        public string GoodPass
        {
            get { return "1234qwer"; }
        }

        public string BadPass
        {
            get { return "1234"; }
        }

        public User ValidNewUser {
            get
            {
                return new User { Email = "goodemail@email.com"};
            }
        }

        public UserServiceTestContext()
        {
            MockUserRepository = new Mock<IUserRepository>();
            MockNotificationService = new Mock<INotificationService>();


            MockUserRepository.Setup(x => x.GetByEmail(ValidUser.Email)).Returns(ValidUser);
            MockUserRepository.Setup(x => x.GetByEmail(PhantomUser.Email)).Returns(null as User);
            MockUserRepository.Setup(x => x.GetByEmail(ValidNewUser.Email)).Returns(null as User);

            UserService = new UserService(MockUserRepository.Object, MockNotificationService.Object);
        }
    }
}
