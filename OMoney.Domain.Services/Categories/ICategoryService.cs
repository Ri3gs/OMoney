using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Categories
{
    public interface ICategoryService
    {
        IQueryable<Category> Get();
        Category Get(int id);
        Category Create(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}
