using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Plans
{
    public class PlanRepository : IPlanRepository
    {
        private readonly DomainDbContext _domainDbContext;

        public PlanRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }

        public void Create(Plan plan)
        {
            _domainDbContext.Plans.Add(plan);
            _domainDbContext.SaveChanges();
        }

        public void Update(Plan plan)
        {
            _domainDbContext.SaveChanges();
        }

        public void Delete(Plan plan)
        {
            _domainDbContext.Plans.Remove(plan);
            _domainDbContext.SaveChanges();
        }

        public List<Plan> GetPlans(User user)
        {
            var plans = _domainDbContext.Plans.Where(x => x.UserId == user.Id).Include(x => x.Categories.Select(c => c.Items));
            if (plans.Any())
            {
                return plans.ToList();
            }
            return null;
        }

        public Plan FindById(int id)
        {
            var plan = _domainDbContext.Plans.Find(id);
            if (plan != null)
            {
                return plan;
            }
            return null;
        }
    }
}
