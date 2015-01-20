using Moq;
using OMoney.Data.Users;
using OMoney.Domain.Services.Validation.Users;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithValidators
{
    public class ValidatorsTestContext
    {
        public Mock<IUserRepository> MockUserRepository { get; set; }
        public CreateNewUserValidator CreateNewUserValidator { get; set; }
        public UpdateUserValidator UpdateUserValidator { get; set; }
        public DeleteUserValidator DeleteUserValidator { get; set; }

        public ValidatorsTestContext()
        {
            CreateNewUserValidator = new CreateNewUserValidator();
            MockUserRepository = new Mock<IUserRepository>();
            UpdateUserValidator = new UpdateUserValidator(MockUserRepository.Object);
            DeleteUserValidator = new DeleteUserValidator(MockUserRepository.Object);
        }
    }
}
