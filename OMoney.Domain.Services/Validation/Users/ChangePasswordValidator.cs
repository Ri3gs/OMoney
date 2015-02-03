using System.Collections.Generic;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Users
{
    public class ChangePasswordValidator
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> Validate(string email, string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (email == null) yield return "Email is NULL.";
            if (oldPassword == null) yield return "Old password is NULL";
            if (newPassword == null) yield return "New password is NULL";
            if (string.IsNullOrWhiteSpace(email)) yield return "Email is empty.";
            if (string.IsNullOrWhiteSpace(oldPassword)) yield return "Old password is EMPTY.";
            if (string.IsNullOrWhiteSpace(newPassword)) yield return "New password is EMPTY.";
            if (string.IsNullOrWhiteSpace(confirmNewPassword)) yield return "Confirm new password is EMPTY.";
            if (newPassword != confirmNewPassword) yield return "New passwords don't match.";
            if (_userRepository.FindUser(email, oldPassword) == null) yield return "No user assosiated with this email. (or typo in password).";
        }
    }
}
