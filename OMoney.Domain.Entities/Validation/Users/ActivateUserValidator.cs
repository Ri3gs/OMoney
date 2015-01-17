﻿using System.Collections.Generic;
using OMoney.Domain.Entities.Entities;

namespace OMoney.Domain.Core.Validation.Users
{
    public class ActivateUserValidator : IDomainEntityValidator<User>
    {
        public IEnumerable<string> Validate(User user)
        {
            if (user == null) yield return "User is NULL.";
            if (user != null && string.IsNullOrWhiteSpace(user.Email)) yield return "Email is EMPTY.";
        }
    }
}
