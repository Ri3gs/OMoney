using System.Linq;
using OMoney.Data.Repositories.Purchases;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Purchases
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

         public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public IQueryable<Purchase> Get()
        {
            return _purchaseRepository.Get();
        }

        public Purchase Get(int id)
        {
            return _purchaseRepository.Get(id);
        }

        public Purchase Create(Purchase purchase)
        {
            return _purchaseRepository.Create(purchase);
        }

        public Purchase Update(Purchase purchase)
        {
            return _purchaseRepository.Update(purchase);
        }

        public void Delete(int id)
        {
            var purchase = _purchaseRepository.Get(id);
            _purchaseRepository.Delete(purchase);
        }
    }
}
