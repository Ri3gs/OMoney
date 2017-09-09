using System.Data.Entity.Migrations;
using System.Linq;
using OMoney.Data.Contexts;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories.Purchases
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DomainDbContext _domainDbContext;

        public PurchaseRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }

        public IQueryable<Purchase> Get()
        {
            return _domainDbContext.Purchases;
        }

        public Purchase Get(int id)
        {
            var purchase = _domainDbContext.Purchases.Find(id);
            return purchase;
        }

        public Purchase Create(Purchase purchase)
        {
            _domainDbContext.Purchases.Add(purchase);
            _domainDbContext.SaveChanges();
            return purchase;
        }

        public Purchase Update(Purchase purchase)
        {
            _domainDbContext.Purchases.AddOrUpdate(purchase);
            _domainDbContext.SaveChanges();
            return purchase;
        }

        public void Delete(Purchase purchase)
        {
            _domainDbContext.Purchases.Remove(purchase);
            _domainDbContext.SaveChanges();
        }
    }
}
