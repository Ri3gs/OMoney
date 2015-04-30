using System;
using System.Collections.Generic;
using System.Linq;
using OMoney.Data.Categories;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.CatItems;

namespace OMoney.Domain.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, ICatItemsService catItemsService)
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
            _categoryRepository.Update(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public void Delete(int id)
        {
            var category = _categoryRepository.FindByid(id);
            Delete(category);
        }

        public List<Category> GetCategories(Plan plan)
        {
            return _categoryRepository.GetCategories(plan);
        }

        public Category FindById(int id)
        {
            return _categoryRepository.FindByid(id);
        }
    }
}
