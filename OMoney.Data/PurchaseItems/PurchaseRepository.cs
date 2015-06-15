using System;
using System.Data.Entity;
using System.Linq;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.PurchaseItems
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DomainDbContext _domainDbContext;

        public PurchaseRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }
        
        //public List<Purchase> GetItems(Category category)
        //{
        //    var purchase = _domainDbContext.PurchaseItems.Where(i => i.CategoryId == category.Id);
        //    if (purchase.Any())
        //    {
        //        return purchase.ToList();
        //    }
        //    return null;
        //}

        //public Purchase Get(int id)
        //{
        //    var purchase = _domainDbContext.PurchaseItems.Find(id);
        //    if (purchase != null)
        //    {
        //        return purchase;
        //    }
        //    return null;
        //}

        //public void Create(Purchase purchase)
        //{
        //    _domainDbContext.PurchaseItems.Add(purchase);
        //    _domainDbContext.SaveChanges();
        //}

        //public void Update(Purchase purchase)
        //{
        //    _domainDbContext.Entry(purchase).State = EntityState.Modified;
        //    _domainDbContext.SaveChanges();
        //}

        //public void Delete(Purchase purchase)
        //{
        //    _domainDbContext.PurchaseItems.Remove(purchase);
        //    _domainDbContext.SaveChanges();
        //}       

        public IQueryable<Purchase> Get()
        {
            return _domainDbContext.PurchaseItems;
        }

        public Purchase Get(int id)
        {
            Purchase purchase = _domainDbContext.PurchaseItems.Find(id);
            return purchase;
        }

        public Purchase Create(Purchase purchase)
        {
            _domainDbContext.PurchaseItems.Add(purchase);
            _domainDbContext.SaveChanges();
            return purchase;
        }

        public Purchase Update(Purchase purchase)
        {
            _domainDbContext.Entry(purchase).State = EntityState.Modified;
            _domainDbContext.SaveChanges();
            return purchase;
        }

        public void Delete(Purchase purchase)
        {
            purchase = _domainDbContext.PurchaseItems.Find(purchase.Id);
            if (purchase != null)
            {
                _domainDbContext.PurchaseItems.Remove(purchase);
                _domainDbContext.SaveChanges();
            }
        }
    }
}
