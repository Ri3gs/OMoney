using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.CatItems
{
    public interface ICatItemsService
    {
        void Create(CatItem item, Category category);
        void Delete(CatItem item, Category category);
        void Delete(int id);

        List<CatItem> GetItems(Category category);
        CatItem FindById(int id);

        void EditItem(CatItem item, Category category);
        void BuyItem(CatItem item, Category category);
        void EditAndBuyItem(CatItem item, Category category);
        void EditBuyedItem(CatItem item, Category category);
        void SellItem(CatItem item, Category category);
    }
}
