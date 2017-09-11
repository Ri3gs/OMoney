using System;
using System.Linq;
using OMoney.Data.Repositories.Accounts;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IQueryable<Account> Get(User user)
        {
            return _accountRepository.Get();
        }

        public Account Get(int id, User user)
        {
            return _accountRepository.Get(id);
        }

        public Account Create(Account account, User user)
        {
            account.CreatedAt = DateTime.Now;
            account.UpdatedAt = DateTime.Now;
            account.UserId = user.Id;
            return _accountRepository.Create(account);
        }

        public Account Update(Account account, User user)
        {
            account.UpdatedAt = DateTime.Now;
            return _accountRepository.Update(account);
        }

        public void Delete(int id, User user)
        {
            var account = _accountRepository.Get(id);
            _accountRepository.Delete(account);
        }
    }
}
