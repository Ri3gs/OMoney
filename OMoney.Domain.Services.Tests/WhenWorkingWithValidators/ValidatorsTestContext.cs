using Moq;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Validation.Users;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithValidators
{
    public class ValidatorsTestContext
    {
        public Mock<IUserRepository> MockUserRepository { get; set; }
        public CreateNewUserValidator CreateNewUserValidator { get; set; }
        public UpdateUserValidator UpdateUserValidator { get; set; }
        public DeleteUserValidator DeleteUserValidator { get; set; }


        public User ValidUser
        {
            get { return new User {Email = "test@email.com", IsActive = true}; }
        }

        public User PhantomUser
        {
            get { return new User {Email = "phantom@gmail.com", IsActive = true}; }
        }

        public string GoodPass
        {
            get { return "1234qwer"; }
        }

        public string BadPass
        {
            get { return "1234"; }
        }

        public ValidatorsTestContext()
        {
            CreateNewUserValidator = new CreateNewUserValidator(string.Empty, string.Empty);
            MockUserRepository = new Mock<IUserRepository>();

            MockUserRepository.Setup(x => x.GetByEmail(ValidUser.Email)).Returns(ValidUser);
            MockUserRepository.Setup(x => x.GetByEmail(PhantomUser.Email)).Returns(null as User);

            UpdateUserValidator = new UpdateUserValidator(MockUserRepository.Object);
            DeleteUserValidator = new DeleteUserValidator(MockUserRepository.Object);
        }

        public void SetPasswords(string password, string confirmPassword)
        {
            CreateNewUserValidator = new CreateNewUserValidator(password, confirmPassword);
        }
    }
}
