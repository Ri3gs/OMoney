using System.Data.Entity.Migrations;
using System.Linq;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DomainDbContext _dataContext;

        public AccountRepository()
        {
            _dataContext = new DomainDbContext();
        }

        public IQueryable<Account> Get()
        {
            return _dataContext.Accounts.AsQueryable();
        }

        public Account Get(int id)
        {
            return Get().FirstOrDefault(x => x.Id == id);
        }

        public Account Create(Account account)
        {
            _dataContext.Accounts.AddOrUpdate(account);
            _dataContext.SaveChanges();
            return account;
        }

        public Account Update(Account account)
        {
            _dataContext.Accounts.AddOrUpdate(account);
            _dataContext.SaveChanges();
            return account;
        }

        public void Delete(Account account)
        {
            _dataContext.Accounts.Remove(account);
            _dataContext.SaveChanges();
        }

        //private readonly DomainDbContext _domainDbContext;

        //public AccountRepository(DomainDbContext domainDbContext)
        //{
        //    _domainDbContext = domainDbContext;
        //}

        //public void CreateAccount(Account account)
        //{
        //    _domainDbContext.Accounts.Add(account);
        //    _domainDbContext.SaveChanges();
        //}

        //public List<Account> GetAccounts(User user)
        //{
        //    var accounts = _domainDbContext.Accounts.Where(a => a.UserId == user.Id).ToList();
        //    return accounts;
        //}

        //public void DeleteAccount(Account account)
        //{
        //    _domainDbContext.Accounts.Remove(account);
        //    _domainDbContext.SaveChanges();
        //}

        //public void UpdateAccount(Account account)
        //{
        //    _domainDbContext.SaveChanges();
        //}

        //public Account FindById(int id)
        //{
        //    var account = _domainDbContext.Accounts.Find(id);
        //    if (account != null)
        //    {
        //        return account;
        //    }
        //    return null;
        //}
    }
}
