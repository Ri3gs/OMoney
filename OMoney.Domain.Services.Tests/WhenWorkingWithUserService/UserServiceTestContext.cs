using System;
using Moq;
using OMoney.Data.Users;
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
            get { return new User {Name = "test", Email = "test@email.com", Password = "1234qwer", ConfirmPassword = "1234qwer", IsActive = true}; }
        }

        public User PhantomUser
        {
            get { return new User { Email = "phantom@gmail.com", Password = "1234qwer", ConfirmPassword = "1234qwer" }; }
        }

        public UserServiceTestContext()
        {
            MockUserRepository = new Mock<IUserRepository>();
            MockNotificationService = new Mock<INotificationService>();


            MockUserRepository.Setup(x => x.GetByEmail(ValidUser.Email)).Returns(ValidUser);
            MockUserRepository.Setup(x => x.GetByEmail(PhantomUser.Email)).Returns(null as User);

            UserService = new UserService(MockUserRepository.Object, MockNotificationService.Object);
        }
    }
}
