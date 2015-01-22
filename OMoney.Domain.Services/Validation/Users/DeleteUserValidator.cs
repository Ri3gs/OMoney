using System.Collections.Generic;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Users
{
    public class DeleteUserValidator : IDomainEntityValidator<User>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> Validate(User user)
        {
            if (user == null) yield return "User is NULL.";
            if (user != null && _userRepository.GetByEmail(user.Email) == null) yield return "User does not exist.";
        }
    }
}