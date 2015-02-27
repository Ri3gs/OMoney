using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DomainDbContext _domainDbContext;
        private readonly UserRepository _userRepository;

        public AccountRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
            _userRepository = new UserRepository();
        }

        public void CreateAccount(Account account)
        {
            _domainDbContext.Accounts.Add(account);
            _domainDbContext.SaveChanges();
        }

        public List<Account> GetAccounts(User user)
        {
            var accounts = _domainDbContext.Accounts.Where(a => a.UserId == user.Id).ToList();
            return accounts;
        }

        public void DeleteAccount(Account account)
        {
            _domainDbContext.Accounts.Remove(account);
            _domainDbContext.SaveChanges();
        }

        public void UpdateAccount(Account account)
        {
            _domainDbContext.SaveChanges();
        }

        public Account FindById(int id)
        {
            var account = _domainDbContext.Accounts.Find(id);
            if (account != null)
            {
                return account;
            }
            return null;
        }
    }
}
