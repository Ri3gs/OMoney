using System.Web.Http;
using AutoMapper;
using OMoney.Data.CatItems;
using OMoney.Domain.Core.Entities;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/catitems")]
    public class CatItemController : ApiController
    {
        private readonly CatItemRepository _catItemRepository;

        public CatItemController(CatItemRepository catItemRepository)
        {
            _catItemRepository = catItemRepository;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(CreateCatItemViewModel model)
        {
            Mapper.CreateMap<CreateCatItemViewModel, CatItem>();
            var catitem = Mapper.Map<CatItem>(model);
            _catItemRepository.Create(catitem);
            return Ok();
        }
    }
}
