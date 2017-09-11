using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OMoney.Domain.Services.Validation.Users
{
    public class FindUserValidator
    {
        private readonly Regex _rgxPwd;
        private readonly Regex _rgxEmail;

        public FindUserValidator()
        {
            _rgxPwd = new Regex(@"^\S*$");
            _rgxEmail = new Regex(@"[a-zA-Z0-9-.+]+@[a-zA-Z0-9-.]+\.[a-zA-Z]{2,}");
        }

        public IEnumerable<string> Validate(string email, string password)
        {
            if (email == null) yield return "Email is NULL.";
            if (email != null && !_rgxEmail.IsMatch(email)) yield return "Email is incorrect.";
            if (!_rgxPwd.IsMatch(password)) yield return "Password is incorrect";
            if (password == null) yield return "Password is NULL";
            if (string.IsNullOrWhiteSpace(email)) yield return "Email is empty.";
            if (string.IsNullOrWhiteSpace(password)) yield return "New password is EMPTY.";
        }
    }
}
