using System.Collections.Generic;
using System.Text.RegularExpressions;
using OMoney.Data.Repositories;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Accounts
{
    public class DeleteAccountValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly Regex _rgx;

        public DeleteAccountValidator(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _rgx = new Regex(@"[a-zA-Z0-9-.+]+@[a-zA-Z0-9-.]+\.[a-zA-Z]{2,}");
        }

        public IEnumerable<string> Validate(int id, string email)
        {
            if (id < 0) yield return "Id cant be like that.";
            //if (_accountRepository.FindById(id) == null) yield return "There is no such account.";
            if (email == null) yield return "Email is NULL.";
            if (email != null && string.IsNullOrWhiteSpace(email)) yield return "Email is EMPTY.";
            if (email != null && _userRepository.GetByEmail(email) == null) yield return "User does not exist.";
            if (email != null && !_rgx.IsMatch(email)) yield return "Email is incorrect.";
            //if (email != null && _userRepository.GetByEmail(email) != null && _accountRepository.FindById(id) != null)
            {
                //if (_userRepository.FindById(_accountRepository.FindById(id).UserId).Email != email) yield return "You can't delete this account, you !@#";
            }
        }

    }
}
