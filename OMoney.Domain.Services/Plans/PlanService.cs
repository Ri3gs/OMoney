using System;
using System.Collections.Generic;
using OMoney.Data.Plans;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Plans
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
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
