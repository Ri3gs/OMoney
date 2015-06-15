using System;
using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.PurchaseItems
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Get();
        Purchase Get(int id);
        Purchase Create(Purchase purchase);
        Purchase Update(Purchase purchase);
        void Delete(Purchase purchase);

       
        
    }
}
