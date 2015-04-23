using System.Collections.Generic;
using System.Linq;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.CatItems
{
    public class CatItemRepository : ICatItemRepository
    {
        private readonly DomainDbContext _domainDbContext;

        public CatItemRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }

        public void Create(CatItem item)
        {
            _domainDbContext.CatItems.Add(item);
            _domainDbContext.SaveChanges();
        }

        public void Update(CatItem item)
        {
            _domainDbContext.SaveChanges();
        }

        public void Delete(CatItem item)
        {
            _domainDbContext.CatItems.Remove(item);
            _domainDbContext.SaveChanges();
        }

        public List<CatItem> GetItems(Category category)
        {
            var items = _domainDbContext.CatItems.Where(i => i.CategoryId == category.Id);
            if (items.Any())
            {
                return items.ToList();
            }
            return null;
        }

        public CatItem FindById(int id)
        {
            var item = _domainDbContext.CatItems.Find(id);
            if (item != null)
            {
                return item;
            }
            return null;
        }
    }
}
