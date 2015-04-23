﻿using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.CatItems
{
    public interface ICatItemRepository
    {
        void Create(CatItem item);
        void Update(CatItem item);
        void Delete(CatItem item);

        List<CatItem> GetItems(Category category);
        CatItem FindById(int id);
    }
}
