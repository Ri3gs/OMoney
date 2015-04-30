using System;
using System.Collections.Generic;
using OMoney.Data.Categories;
using OMoney.Data.CatItems;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.CatItems
{
    public class CatItemsService : ICatItemsService
    {
        private readonly ICatItemRepository _catItemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CatItemsService(ICatItemRepository catItemRepository, ICategoryRepository categoryRepository)
        {
            _catItemRepository = catItemRepository;
            _categoryRepository = categoryRepository;
        }

        public void Create(CatItem item, Category category)
        {
            if (item.Price != 0)
            {
                category.CatItemsTotalPrice += item.Price;
                category.Planned += item.Price;
            }

            if (item.Buyed)
            {
                item.BuyedTime = DateTime.Now;
                category.Spent += item.Price;
                _categoryRepository.Update(category);
                _catItemRepository.Create(item);
            }
            else
            {
                item.BuyedTime = null;
                _categoryRepository.Update(category);
                _catItemRepository.Create(item);
            }
        }

        

        public void Delete(CatItem item, Category category)
        {
            if (item.Buyed)
            {
                category.Spent -= item.Price;
            }
            category.Planned -= item.Price;
            category.CatItemsTotalPrice -= item.Price;
            _categoryRepository.Update(category);
            _catItemRepository.Delete(item);
        }

        public void Delete(int id)
        {
            var item = _catItemRepository.FindById(id);
            var category = _categoryRepository.FindByid(item.CategoryId);
            Delete(item, category);
        }

        public List<CatItem> GetItems(Category category)
        {
            return _catItemRepository.GetItems(category);
        }

        public CatItem FindById(int id)
        {
            return _catItemRepository.FindById(id);
        }

        public void EditItem(CatItem item, Category category)
        {
            var oldItem = _catItemRepository.FindById(item.Id);
            oldItem.Name = item.Name;
            if (oldItem.Price != item.Price)
            {
                category.Planned += item.Price - oldItem.Price;
                category.CatItemsTotalPrice += item.Price - oldItem.Price;
                _categoryRepository.Update(category);
                oldItem.Price = item.Price;
            }
            _catItemRepository.Update(oldItem);
        }

        public void BuyItem(CatItem item, Category category)
        {
            var oldItem = _catItemRepository.FindById(item.Id);
            oldItem.Buyed = true;
            oldItem.BuyedTime = DateTime.Now;
            category.Spent += item.Price;
            _catItemRepository.Update(oldItem);
            _categoryRepository.Update(category);
        }

        public void EditAndBuyItem(CatItem item, Category category)
        {
            var oldItem = _catItemRepository.FindById(item.Id);
            oldItem.Name = item.Name;
            oldItem.Buyed = true;
            oldItem.BuyedTime = DateTime.Now;
            if (oldItem.Price != item.Price)
            {
                category.Planned += item.Price - oldItem.Price;
                category.CatItemsTotalPrice += item.Price - oldItem.Price;
                category.Spent += item.Price;
                oldItem.Price = item.Price;
                _categoryRepository.Update(category);
            }
            else
            {
                category.Spent += item.Price;
                _categoryRepository.Update(category);
            }
            _catItemRepository.Update(oldItem);
        }

        public void EditBuyedItem(CatItem item, Category category)
        {
            var oldItem = _catItemRepository.FindById(item.Id);
            oldItem.Name = item.Name;
            if (oldItem.Price != item.Price)
            {
                category.Planned += item.Price - oldItem.Price;
                category.CatItemsTotalPrice += item.Price - oldItem.Price;
                category.Spent += item.Price - oldItem.Price;
                _categoryRepository.Update(category);
            }

            _catItemRepository.Update(oldItem);
        }

        public void SellItem(CatItem item, Category category)
        {
            var oldItem = _catItemRepository.FindById(item.Id);
            oldItem.Buyed = false;
            oldItem.BuyedTime = null;
            category.Spent -= oldItem.Price;
            _catItemRepository.Update(oldItem);
            _categoryRepository.Update(category);
        }
    }
}
