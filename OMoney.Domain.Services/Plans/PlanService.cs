using System;
using System.Linq;
using OMoney.Data.Repositories.Plans;
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

        public IQueryable<Plan> Get()
        {
            return _planRepository.Get();
        }

        public Plan Get(int id)
        {
            return _planRepository.Get(id);
        }

        public Plan Create(Plan plan)
        {
            plan.CreatedAt = DateTime.Now;
            plan.UpdatedAt = DateTime.Now;
            return _planRepository.Create(plan);
        }

        public Plan Update(Plan plan)
        {
            plan.UpdatedAt = DateTime.Now;
            return _planRepository.Update(plan);
        }

        public void Delete(int id)
        {
            var plan = _planRepository.Get(id);
            _planRepository.Delete(plan);
        }
    }
}
