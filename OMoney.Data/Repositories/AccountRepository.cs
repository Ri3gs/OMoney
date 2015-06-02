using System.Data.Entity.Migrations;
using System.Linq;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DomainDbContext _dataContext;

        public AccountRepository(DomainDbContext dataContext)
        {
            _dataContext = dataContext;
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
    }
}
