using System;
using System.Collections.Generic;
using System.Linq;
using OMoney.Data.Categories;
using OMoney.Data.Plans;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Categories;

namespace OMoney.Domain.Services.Plans
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        public PlanService(IPlanRepository planRepository, ICategoryRepository categoryRepository, ICategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _planRepository = planRepository;
            _categoryService = categoryService;
        }

        public void Create(Plan plan)
        {
            plan.CreatedAt = DateTime.Now;
            plan.UpdatedAt = DateTime.Now;
            _planRepository.Create(plan);
        }

        public void Update(Plan plan)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Plan plan)
        {
            _planRepository.Delete(plan);
        }

        public void Delete(int id)
        {
            var plan = _planRepository.FindById(id);
            var categories = _categoryService.GetCategories(plan);
            if (categories!= null && categories.Any())
            {
                foreach (var category in categories)
                {
                    _categoryService.Delete(category);
                }
            }
            _planRepository.Delete(plan);
        }

        public List<Plan> GetPlans(User user)
        {
            return _planRepository.GetPlans(user);
        }

        public Plan FindById(int id)
        {
            return _planRepository.FindById(id);
        }
    }
}
