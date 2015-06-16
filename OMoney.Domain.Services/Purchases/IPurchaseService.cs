using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Purchases
{
    public interface IPurchaseService
    {
        IQueryable<Purchase> Get();
        Purchase Get(int id);
        Purchase Create(Purchase purchase);
        Purchase Update(Purchase purchase);
        void Delete(int id);
    }
}
