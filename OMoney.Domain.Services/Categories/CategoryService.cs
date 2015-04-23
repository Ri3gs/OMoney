using System;
using System.Collections.Generic;
using System.Linq;
using OMoney.Data.Categories;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(Category category)
        {
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            _categoryRepository.Create(category);
        }

        public void Update(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public List<Category> GetCategories(Plan plan)
        {
            return _categoryRepository.GetCategories(plan);
        }
    }
}
