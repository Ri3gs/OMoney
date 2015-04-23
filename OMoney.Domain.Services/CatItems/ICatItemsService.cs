using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.CatItems
{
    public interface ICatItemsService
    {
        void Create(CatItem item);
        void Update(CatItem item);
        void Delete(CatItem item);
        void Delete(int id);

        List<CatItem> GetItems(Category category);
        CatItem FindById(int id);
    }
}
