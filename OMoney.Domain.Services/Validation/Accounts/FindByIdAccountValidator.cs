using System.Collections.Generic;
using System.Text.RegularExpressions;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Accounts
{
    public class FindByIdAccountValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly Regex _rgx;

        public FindByIdAccountValidator(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _rgx = new Regex(@"[a-zA-Z0-9-.+]+@[a-zA-Z0-9-.]+\.[a-zA-Z]{2,}");
        }

        public IEnumerable<string> Validate(int id, string email)
        {
            if (email == null) yield return "Email is null.";
            if (email != null && !_rgx.IsMatch(email)) yield return "Email is incorrect.";
            if (email != null && string.IsNullOrWhiteSpace(email)) yield return "Email is EMPTY.";
            if (!string.IsNullOrWhiteSpace(email) & _rgx.IsMatch(email))
            {
                if (_userRepository.GetByEmail(email) == null) yield return "User must exist";
                if (_accountRepository.FindById(id) == null) yield return "Account must exist";
                if (_accountRepository.FindById(id) != null && _accountRepository.FindById(id).UserId != _userRepository.GetId(email))
                    yield return "You can't view other people accs.";
                if (!_userRepository.CheckEmail(email)) yield return "Email must be confirmed.";
            }
        }
    }
}
