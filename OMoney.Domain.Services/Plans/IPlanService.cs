using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Plans
{
    public interface IPlanService
    {
        IQueryable<Plan> Get(User user);
        Plan Get(int id, User user);
        Plan Create(Plan plan, User user);
        Plan Update(Plan plan);
        void Delete(int id);
    }
}
