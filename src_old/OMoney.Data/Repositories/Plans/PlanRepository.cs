using System.Data.Entity.Migrations;
using System.Linq;
using OMoney.Data.Contexts;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories.Plans
{
    public class PlanRepository : IPlanRepository
    {
        private readonly DomainDbContext _domainDbContext;

        public PlanRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }

        public IQueryable<Plan> Get()
        {
            return _domainDbContext.Plans.AsQueryable();
        }

        public Plan Get(int id)
        {
            return Get().FirstOrDefault(p => p.Id == id);
        }

        public Plan Create(Plan plan)
        {
            _domainDbContext.Plans.Add(plan);
            _domainDbContext.SaveChanges();
            return plan;
        }

        public Plan Update(Plan plan)
        {
            _domainDbContext.Plans.AddOrUpdate(plan);
            _domainDbContext.SaveChanges();
            return plan;
        }

        public void Delete(Plan plan)
        {
            _domainDbContext.Plans.Remove(plan);
            _domainDbContext.SaveChanges();
        }
    }
}
