using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories.Plans
{
    public interface IPlanRepository
    {
        IQueryable<Plan> Get();
        Plan Get(int id);
        Plan Create(Plan plan);
        Plan Update(Plan plan);
        void Delete(Plan plan);
    }
}
