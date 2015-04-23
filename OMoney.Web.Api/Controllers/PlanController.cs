using System.Web.Http;
using AutoMapper;
using OMoney.Domain.Services.Plans;
using OMoney.Domain.Services.Users;
using OMoney.Web.Api.Models;
using Plan = OMoney.Domain.Core.Entities.Plan;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/plan")]
    public class PlanController : ApiController
    {
        private readonly IPlanService _planService;
        private readonly IUserService _userService;

        public PlanController(IPlanService planService, IUserService userService)
        {
            _userService = userService;
            _planService = planService;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(CreatePlanViewModel model)
        {
            Plan plan = new Plan {Month = model.Month, UserId = _userService.GetByEmail(model.Email).Id};
            _planService.Create(plan);
            return Ok();
        }

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll(string email)
        {
            var user = _userService.GetByEmail(email);
            var plans = _planService.GetPlans(user);
            return Ok(plans);
        }

        [HttpGet]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _planService.Delete(id);
            return Ok();
        }
    }
}
