using System.Web.Http;
using AutoMapper;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.CatItems;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/catitems")]
    public class CatItemController : ApiController
    {
        private readonly ICatItemsService _catItemsService;

        public CatItemController(ICatItemsService catItemsService)
        {
            _catItemsService = catItemsService;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(CreateCatItemViewModel model)
        {
            Mapper.CreateMap<CreateCatItemViewModel, CatItem>();
            var catitem = Mapper.Map<CatItem>(model);
            _catItemsService.Create(catitem);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update(UpdateCatItemViewModel model)
        {
            Mapper.CreateMap<UpdateCatItemViewModel, CatItem>();
            var catitem = Mapper.Map<CatItem>(model);
            _catItemsService.Update(catitem);
            return Ok();
        }

        [HttpGet]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _catItemsService.Delete(id);
            return Ok();
        }
    }
}
