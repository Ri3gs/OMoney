using System.Collections.Generic;
using System.Text.RegularExpressions;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Users
{
    public class ChangePasswordValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly Regex _rgx;

        public ChangePasswordValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _rgx = new Regex(@"[a-zA-Z0-9-.+]+@[a-zA-Z0-9-.]+\.[a-zA-Z]{2,}");
        }

        public IEnumerable<string> Validate(string email, string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (email == null) yield return "Email is NULL.";
            if (email != null && !_rgx.IsMatch(email)) yield return "Email is incorrect.";
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
