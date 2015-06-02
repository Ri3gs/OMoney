using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DomainDbContext _dataContext;

        public CurrencyRepository(DomainDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Currency> Get(User user)
        {
            return _dataContext.Currencies.Where(c => c.UserId == user.Id).AsQueryable();
        }

        public Currency Get(int id)
        {
            return _dataContext.Currencies.FirstOrDefault(x => x.Id == id);
        }

        public Currency Create(Currency currency)
        {
            _dataContext.Currencies.Add(currency);
            _dataContext.SaveChanges();
            return currency;
        }

        public Currency Update(Currency currency)
        {
            _dataContext.Currencies.AddOrUpdate(currency);
            _dataContext.SaveChanges();
            return currency;
        }

        public void Delete(Currency currency)
        {
            _dataContext.Currencies.Remove(currency);
            _dataContext.SaveChanges();
        }
    }
}
