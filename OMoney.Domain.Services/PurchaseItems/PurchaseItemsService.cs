using System;
using OMoney.Data.PurchaseItems;
using OMoney.Domain.Core.Entities;
using System.Linq;

namespace OMoney.Domain.Services.PurchaseItems
{
    public class PurchaseItemsService : IPurchaseItemsService
    {
        private readonly IPurchaseRepository _purchaseRepository;

         public PurchaseItemsService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public IQueryable<Purchase> Get()
        {
            return _purchaseRepository.Get();
        }

        public Purchase Get(Guid id)
        {
            return _purchaseRepository.Get(id);
        }

        public Purchase Create(Purchase purchase)
        {
            purchase.Buyed = true;
            purchase.BuyedTime = DateTime.Now;
            return _purchaseRepository.Create(purchase);
        }

        public Purchase Update(Purchase purchase)
        {
            purchase.BuyedTime = DateTime.Now;
            return _purchaseRepository.Update(purchase);
        }

        public void Delete(Purchase purchase)
        {
            purchase = _purchaseRepository.Get(purchase.Id);
            _purchaseRepository.Delete(purchase);
        }


        //private readonly ICategoryRepository _categoryRepository;

        //public PurchaseItemsService(IPurchaseRepository purchaseRepository, ICategoryRepository categoryRepository)
        //{
        //    _purchaseRepository = purchaseRepository;
        //    _categoryRepository = categoryRepository;
        //}

        //public void Create(Purchase purchase, Category category)
        //{
        //    if (purchase.Price != 0)
        //    {
        //        category.PurchaseItemsTotalPrice += purchase.Price;
        //        category.Planned += purchase.Price;
        //    }

        //    if (purchase.Buyed)
        //    {
        //        purchase.BuyedTime = DateTime.Now;
        //        category.Spent += purchase.Price;
        //        _categoryRepository.Update(category);
        //        _purchaseRepository.Create(purchase);
        //    }
        //    else
        //    {
        //        purchase.BuyedTime = null;
        //        _categoryRepository.Update(category);
        //        _purchaseRepository.Create(purchase);
        //    }

        //public void Delete(Purchase purchase, Category category)
        //{
        //    if (purchase.Buyed)
        //    {
        //        category.Spent -= purchase.Price;
        //    }
        //    category.Planned -= purchase.Price;
        //    category.PurchaseItemsTotalPrice -= purchase.Price;
        //    _categoryRepository.Update(category);
        //    _purchaseRepository.Delete(purchase);
        //}

        //public void Delete(int id)
        //{
        //    var purchase = _purchaseRepository.Get(id);
        //    var category = _categoryRepository.FindByid(purchase.CategoryId);
        //    Delete(purchase, category);
        //}

        //public List<Purchase> GetItems(Category category)
        //{
        //    return _purchaseRepository.GetItems(category);
        //}

        //public Purchase Get(int id)
        //{
        //    return _purchaseRepository.Get(id);
        //}

        //public void EditItem(Purchase purchase, Category category)
        //{
        //    var oldPurchase = _purchaseRepository.Get(purchase.Id);
        //    oldPurchase.Name = purchase.Name;
        //    if (oldPurchase.Price != purchase.Price)
        //    {
        //        category.Planned += purchase.Price - oldPurchase.Price;
        //        category.PurchaseItemsTotalPrice += purchase.Price - oldPurchase.Price;
        //        _categoryRepository.Update(category);
        //        oldPurchase.Price = purchase.Price;
        //    }
        //    _purchaseRepository.Update(oldPurchase);
        //}

        //public void BuyItem(Purchase purchase, Category category)
        //{
        //    var oldIPurchase = _purchaseRepository.Get(purchase.Id);
        //    oldIPurchase.Buyed = true;
        //    oldIPurchase.BuyedTime = DateTime.Now;
        //    category.Spent += purchase.Price;
        //    _purchaseRepository.Update(oldIPurchase);
        //    _categoryRepository.Update(category);
        //}

        //public void EditAndBuyItem(Purchase purchase, Category category)
        //{
        //    var oldPurchase = _purchaseRepository.Get(purchase.Id);
        //    oldPurchase.Name = purchase.Name;
        //    oldPurchase.Buyed = true;
        //    oldPurchase.BuyedTime = DateTime.Now;
        //    if (oldPurchase.Price != purchase.Price)
        //    {
        //        category.Planned += purchase.Price - oldPurchase.Price;
        //        category.PurchaseItemsTotalPrice += purchase.Price - oldPurchase.Price;
        //        category.Spent += purchase.Price;
        //        oldPurchase.Price = purchase.Price;
        //        _categoryRepository.Update(category);
        //    }
        //    else
        //    {
        //        category.Spent += purchase.Price;
        //        _categoryRepository.Update(category);
        //    }
        //    _purchaseRepository.Update(oldPurchase);
        //}

        //public void EditBuyedItem(Purchase purchase, Category category)
        //{
        //    var oldPurchase = _purchaseRepository.Get(purchase.Id);
        //    oldPurchase.Name = purchase.Name;
        //    if (oldPurchase.Price != purchase.Price)
        //    {
        //        category.Planned += purchase.Price - oldPurchase.Price;
        //        category.PurchaseItemsTotalPrice += purchase.Price - oldPurchase.Price;
        //        category.Spent += purchase.Price - oldPurchase.Price;
        //        _categoryRepository.Update(category);
        //        oldPurchase.Price = purchase.Price;
        //    }

        //    _purchaseRepository.Update(oldPurchase);
        //}

        //public void SellItem(Purchase purchase, Category category)
        //{
        //    var oldPurchase = _purchaseRepository.Get(purchase.Id);
        //    oldPurchase.Buyed = false;
        //    oldPurchase.BuyedTime = null;
        //    category.Spent -= oldPurchase.Price;
        //    _purchaseRepository.Update(oldPurchase);
        //    _categoryRepository.Update(category);
        //}
    }
}
