using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Plans
{
    public interface IPlanService
    {
        IQueryable<Plan> Get();
        Plan Get(int id);
        Plan Create(Plan plan);
        Plan Update(Plan plan);
        void Delete(int id);
    }
}
