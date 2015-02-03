using System.Collections.Generic;
using OMoney.Data.Users;

namespace OMoney.Domain.Services.Validation.Users
{
    public class SendResetLinkValidator
    {
        private readonly IUserRepository _userRepository;

        public SendResetLinkValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> Validate(string email)
        {
            if (email == null) yield return "Email is NULL.";
            if (email != null && string.IsNullOrWhiteSpace(email)) yield return "Email is EMPTY.";
            if (email != null && _userRepository.GetByEmail(email) == null) yield return "User does not exist.";
        }
    }
}
