using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Categories
{
    public interface ICategoryService
    {
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Delete(int id);

        List<Category> GetCategories(Plan plan);
        Category FindById(int id);
    }
}
