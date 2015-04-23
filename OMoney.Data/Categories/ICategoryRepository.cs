using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Categories
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);

        List<Category> GetCategories(Plan plan);
    }
}
