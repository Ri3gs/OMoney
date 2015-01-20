using System.Collections.Generic;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Users
{
    public class UpdateUserValidator : IDomainEntityValidator<User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> Validate(User user)
        {
            if (user == null) yield return "User is NULL.";
            if (user != null && string.IsNullOrWhiteSpace(user.Email)) yield return "Email is EMPTY.";
            if (user != null && string.IsNullOrWhiteSpace(user.Password)) yield return "Password is EMPTY.";
            if (user != null && string.IsNullOrWhiteSpace(user.ConfirmPassword)) yield return "Password Confirm is EMPTY.";
            if (user != null && user.Password != user.ConfirmPassword) yield return "Password and Confirm Password does not match.";
            // if (user != null && _userRepository.GetByEmail(user.Email) == null) yield return "User does not exist.";
        }
    }
}
