using System.Collections.Generic;
using System.Text.RegularExpressions;
using OMoney.Data.Users;

namespace OMoney.Domain.Services.Validation.Users
{
    public class SendResetLinkValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly Regex _rgx;

        public SendResetLinkValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _rgx = new Regex(@"[a-zA-Z0-9-.+]+@[a-zA-Z0-9-.]+\.[a-zA-Z]{2,}");
        }

        public IEnumerable<string> Validate(string email)
        {
            if (email == null) yield return "Email is NULL.";
            if (email != null && string.IsNullOrWhiteSpace(email)) yield return "Email is EMPTY.";
            if (email != null && _userRepository.GetByEmail(email) == null) yield return "User does not exist.";
            if (email != null && !_rgx.IsMatch(email)) yield return "Email is incorrect.";
        }
    }
}
