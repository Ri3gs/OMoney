using System.Web.Http;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Plans;

namespace OMoney.Web.Api.Controllers
{
    [Authorize]
    public class PlanController : ApiController
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_planService.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_planService.Get(id));
        }

        public IHttpActionResult Post(Plan plan)
        {
            return Ok(_planService.Create(plan));
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


        //[HttpPost]
        //[Route("create")]
        //public IHttpActionResult Create(CreatePlanViewModel model)
        //{
        //    Plan plan = new Plan {Month = model.Month, UserId = _userService.GetByEmail(model.Email).Id};
        //    _planService.Create(plan);
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("getall")]
        //public IHttpActionResult GetAll(string email)
        //{
        //    var user = _userService.GetByEmail(email);
        //    var plans = _planService.GetPlans(user);
        //    return Ok(plans);
        //}

        //[HttpGet]
        //[Route("delete")]
        //public IHttpActionResult Delete(int id)
        //{
        //    _planService.Delete(id);
        //    return Ok();
        //}
    }
}
