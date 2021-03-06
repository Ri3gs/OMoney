﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OMoney.Data.Repositories;
using OMoney.Data.Repositories.Users;

namespace OMoney.Domain.Services.Validation.Users
{
    public class ResetPasswordValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly Regex _rgxPwd;

        public ResetPasswordValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _rgxPwd = new Regex(@"^\S*$");
        }

        public IEnumerable<string> Validate(string userId, string code, string newPassword, string confirmNewPassword)
        {
            if (userId == null) yield return "UserId is NULL.";
            if (code == null) yield return "Code is NULL";
            if (newPassword == null) yield return "New password is NULL.";
            if (string.IsNullOrWhiteSpace(userId)) yield return "UserId is EMPTY.";
            if (string.IsNullOrWhiteSpace(code)) yield return "Code is EMPTY.";
            if (string.IsNullOrWhiteSpace(newPassword)) yield return "New password is EMPTY.";
            if (_userRepository.FindById(userId) == null) yield return "User does not exist.";
            if (newPassword != confirmNewPassword) yield return "New password and confirm new password does not match.";
            if (newPassword != null && !_rgxPwd.IsMatch(newPassword)) yield return "New password is incorrect";
            if (confirmNewPassword != null && !_rgxPwd.IsMatch(confirmNewPassword)) yield return "Confirm new password is incorrect";
        }
    }
}
