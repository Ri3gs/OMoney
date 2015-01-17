using System.Collections.Generic;
using OMoney.Domain.Entities.Entities;

namespace OMoney.Domain.Core.Validation.Users
{
    public class CreateNewUserValidator : IDomainEntityValidator<User>
    {
        public IEnumerable<string> Validate(User user)
        {
            if (user == null) yield return "User is NULL";
            if (user != null && string.IsNullOrWhiteSpace(user.Email)) yield return "Email is EMPTY.";
            if (user != null && string.IsNullOrWhiteSpace(user.Password)) yield return "Password is EMPTY.";
            if (user != null && string.IsNullOrWhiteSpace(user.ConfirmPassword)) yield return "Password Confirm is EMPTY.";
            if (user != null && user.Password != user.ConfirmPassword) yield return "Password and Confirm Password does not match.";
        }
    }
}
