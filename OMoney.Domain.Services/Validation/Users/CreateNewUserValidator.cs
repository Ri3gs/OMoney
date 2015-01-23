using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Users
{
    public class CreateNewUserValidator : ICreateNewUserValidator<User>
    {
        public IEnumerable<string> Validate(User user, string password, string confirmPassword)
        {
            if (user == null) yield return "User is NULL.";
            if (user != null && string.IsNullOrWhiteSpace(user.Email)) yield return "Email is EMPTY.";
            if (user != null && string.IsNullOrWhiteSpace(password)) yield return "Password is EMPTY.";
            if (user != null && string.IsNullOrWhiteSpace(confirmPassword)) yield return "Password Confirm is EMPTY.";
            if (user != null && password != confirmPassword) yield return "Password and Confirm Password does not match.";
        }
    }
}
