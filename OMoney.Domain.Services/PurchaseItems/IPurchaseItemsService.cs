using System;
using System.Collections.Generic;
using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.PurchaseItems
{
    public interface IPurchaseItemsService
    {
        //void Create(Purchase purchase, Category category);
        //void Delete(Purchase purchase, Category category);
        //void Delete(int id);

        //List<Purchase> GetItems(Category category);
        //Purchase Get(int id);

        //void EditItem(Purchase purchase, Category category);
        //void BuyItem(Purchase purchase, Category category);
        //void EditAndBuyItem(Purchase purchase, Category category);
        //void EditBuyedItem(Purchase purchase, Category category);
        //void SellItem(Purchase purchase, Category category);

        IQueryable<Purchase> Get();
        Purchase Get(Guid id);
        Purchase Create(Purchase purchase);
        Purchase Update(Purchase purchase);
        void Delete(Purchase purchase);
    }
}
