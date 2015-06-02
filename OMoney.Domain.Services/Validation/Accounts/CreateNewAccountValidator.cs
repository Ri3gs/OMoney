using System.Collections.Generic;
using OMoney.Data.Repositories;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Accounts
{
    public class CreateNewAccountValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public CreateNewAccountValidator(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public IEnumerable<string> Validate(Account account, string email)
        {
            if (account == null) yield return "Account is null.";
            if (email == null) yield return "Email is null.";
            if (account != null && string.IsNullOrWhiteSpace(account.Name)) yield return "Name null or empty";
            if (account != null && account.Amount < 0) yield return "Amount cant be < 0.";
            if (string.IsNullOrWhiteSpace(email)) yield return "Email is empty.";
            if (_userRepository.GetByEmail(email) == null) yield return "User must exist";
            if (!_userRepository.CheckEmail(email)) yield return "Email must be confirmed.";
            //var count = _accountRepository.GetAccounts(_userRepository.GetByEmail(email)).Count;
            //if (!_userRepository.GetByEmail(email).IsGold && count == 3)
            //    yield return "Upgrade to premium for more than 3 accounts.";
        }
    }
}
