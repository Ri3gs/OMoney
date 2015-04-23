using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Plans
{
    public interface IPlanRepository
    {
        void Create(Plan plan);
        void Update(Plan plan);
        void Delete(Plan plan);

        List<Plan> GetPlans(User user);
        Plan FindById(int id);
    }
}
