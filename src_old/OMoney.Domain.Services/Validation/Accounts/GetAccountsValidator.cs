using System.Collections.Generic;
using System.Text.RegularExpressions;
using OMoney.Data.Repositories;
using OMoney.Data.Repositories.Accounts;
using OMoney.Data.Repositories.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Accounts
{
    public class GetAccountsValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly Regex _rgx;

        public GetAccountsValidator(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _rgx = new Regex(@"[a-zA-Z0-9-.+]+@[a-zA-Z0-9-.]+\.[a-zA-Z]{2,}");
        }

        public IEnumerable<string> Validate(string email, string whoWantsToKnowEmail)
        {
            if (email != whoWantsToKnowEmail) yield return "You cannot view other users accounts";

            if (email == null) yield return "Email is null.";
            if (email != null && !_rgx.IsMatch(email)) yield return "Email is incorrect.";
            if (email != null && string.IsNullOrWhiteSpace(email)) yield return "Email is EMPTY.";
            if (_userRepository.GetByEmail(email) == null) yield return "User must exist";
            if (!string.IsNullOrWhiteSpace(email) & _rgx.IsMatch(email) && _userRepository.GetByEmail(email) != null)
            {
                if (!_userRepository.CheckEmail(email)) yield return "Email must be confirmed.";
            }
            
        }
    }
}
