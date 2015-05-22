using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Accounts
{
    public class UpdateAccountValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly Regex _rgx;

        public UpdateAccountValidator(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _rgx = new Regex(@"[a-zA-Z0-9-.+]+@[a-zA-Z0-9-.]+\.[a-zA-Z]{2,}");
        }

        public IEnumerable<string> Validate(Account account, string email)
        {
            if (account == null) yield return "Account is null.";
            //if (account != null && _accountRepository.FindById(account.Id) == null) yield return "There is no such account.";

            if (account != null && account.Id <= 0) yield return "Id cant be like that.";
            if (account != null && account.Amount < 0) yield return "Amount cant be < 0.";
            if (account != null && string.IsNullOrWhiteSpace(account.Name)) yield return "Name null or empty";
            if (account != null && account.UserId != null) yield return "You cant change the owner of the account.";

            if (email == null) yield return "Email is null.";
            if (email != null && !_rgx.IsMatch(email)) yield return "Email is incorrect.";
            if (email != null && string.IsNullOrWhiteSpace(email)) yield return "Email is EMPTY.";

            if (!string.IsNullOrWhiteSpace(email) & _rgx.IsMatch(email))
            {
                if (_userRepository.GetByEmail(email) == null) yield return "User must exist";
                if (!_userRepository.CheckEmail(email)) yield return "Email must be confirmed.";
            }
            //if (account != null && (email != null && _userRepository.GetByEmail(email) != null && _accountRepository.FindById(account.Id) != null))
            //{
            //    //if (_userRepository.FindById(_accountRepository.FindById(account.Id).UserId).Email != email) yield return "You can't update this account, you !@#";
            //}
        }
    }
}
