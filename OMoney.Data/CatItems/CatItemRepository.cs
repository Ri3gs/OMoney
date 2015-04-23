using System;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public void Delete(CatItem item)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetItems(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
