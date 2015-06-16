using System.Web.Http;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Plans;
using OMoney.Web.Api.Context;

namespace OMoney.Web.Api.Controllers
{
    [Authorize]
    public class PlanController : ApiController
    {
        private readonly IPlanService _planService;
        private readonly ICurrentUser _currentUser;

        public PlanController(IPlanService planService, ICurrentUser currentUser)
        {
            _currentUser = currentUser;
            _planService = planService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_planService.Get(_currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_planService.Get(id, _currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Post(Plan plan)
        {
            return Ok(_planService.Create(plan, _currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Put(Plan plan)
        {
            return Ok(_planService.Update(plan));
        }

        public IHttpActionResult Delete(int id)
        {
            _planService.Delete(id);
            return Ok();
        }
    }
}
