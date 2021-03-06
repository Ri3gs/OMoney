﻿using Moq;
using OMoney.Data.Repositories;
using OMoney.Data.Repositories.Users;
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
            get { return new User {Email = "test@email.com"}; }
        }

        public User PhantomUser
        {
            get { return new User {Email = "phantom@gmail.com"}; }
        }

        public User ValidNewUser {
            get
            {
                return new User  {Email = "goodemail@email.com"};
            }
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
            MockUserRepository = new Mock<IUserRepository>();

            MockUserRepository.Setup(x => x.GetByEmail(ValidUser.Email)).Returns(ValidUser);
            MockUserRepository.Setup(x => x.GetByEmail(PhantomUser.Email)).Returns(null as User);
            MockUserRepository.Setup(x => x.GetByEmail(ValidNewUser.Email)).Returns(null as User);

            CreateNewUserValidator = new CreateNewUserValidator(MockUserRepository.Object, string.Empty, string.Empty);
            UpdateUserValidator = new UpdateUserValidator(MockUserRepository.Object);
            DeleteUserValidator = new DeleteUserValidator(MockUserRepository.Object);
        }

        public void SetPasswords(string password, string confirmPassword)
        {
            CreateNewUserValidator = new CreateNewUserValidator(MockUserRepository.Object, password, confirmPassword);
        }
    }
}
