using System.Collections.Generic;
using OMoney.Data.CatItems;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.CatItems
{
    public class CatItemsService : ICatItemsService
    {
        private readonly ICatItemRepository _catItemRepository;

        public CatItemsService(ICatItemRepository catItemRepository)
        {
            _catItemRepository = catItemRepository;
        }

        public void Create(CatItem item)
        {
            _catItemRepository.Create(item);
        }

        public void Update(CatItem item)
        {
            var oldItem = _catItemRepository.FindById(item.Id);
            oldItem.Name = item.Name;
            _catItemRepository.Update(oldItem);
        }

        public void Delete(CatItem item)
        {
            _catItemRepository.Delete(item);
        }

        public void Delete(int id)
        {
            var item = _catItemRepository.FindById(id);
            Delete(item);
        }

        public List<CatItem> GetItems(Category category)
        {
            return _catItemRepository.GetItems(category);
        }

        public CatItem FindById(int id)
        {
            return _catItemRepository.FindById(id);
        }
    }
}
