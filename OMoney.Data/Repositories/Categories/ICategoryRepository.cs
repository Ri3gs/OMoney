using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories.Categories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Get();
        Category Get(int id);
        Category Create(Category category);
        Category Update(Category category);
        void Delete(Category category);
    }
}
