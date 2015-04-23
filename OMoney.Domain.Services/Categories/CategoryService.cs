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
        private readonly ICatItemsService _catItemsService;

        public CategoryService(ICategoryRepository categoryRepository, ICatItemsService catItemsService)
        {
            _categoryRepository = categoryRepository;
            _catItemsService = catItemsService;
        }

        public void Create(Category category)
        {
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            _categoryRepository.Create(category);
        }

        public void Update(Category category)
        {
            var oldCategory = _categoryRepository.FindByid(category.Id);
            oldCategory.Currency = category.Currency;
            oldCategory.Name = category.Name;
            oldCategory.Planned = category.Planned;
            oldCategory.Spent = category.Spent;
            oldCategory.UpdatedAt = DateTime.Now;
            _categoryRepository.Update(oldCategory);
        }

        public void Delete(Category category)
        {
            var catItems = _catItemsService.GetItems(category);
            if (catItems != null && catItems.Any())
            {
                foreach (var catItem in catItems)
                {
                    _catItemsService.Delete(catItem);
                }
            }
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
