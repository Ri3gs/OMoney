using System.Collections.Generic;

namespace OMoney.Domain.Services.Validation.Users
{
    public class CheckByEmailValidator
    {
        public IEnumerable<string> Validate(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) yield return "Email is EMPTY.";
        }
    }
}
