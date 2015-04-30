using System.Web.Http;
using AutoMapper;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Categories;
using OMoney.Domain.Services.CatItems;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/catitems")]
    public class CatItemController : ApiController
    {
        private readonly ICatItemsService _catItemsService;
        private readonly ICategoryService _categoryService;

        public CatItemController(ICatItemsService catItemsService, ICategoryService categoryService)
        {
            _catItemsService = catItemsService;
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(CreateCatItemViewModel model)
        {
            Mapper.CreateMap<CreateCatItemViewModel, CatItem>();
            var catitem = Mapper.Map<CatItem>(model);
            var category = _categoryService.FindById(model.CategoryId);
            _catItemsService.Create(catitem, category);
            return Ok();
        }

        [HttpGet]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _catItemsService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("edit")]
        public IHttpActionResult Edit(UpdateCatItemViewModel model)
        {
            Mapper.CreateMap<UpdateCatItemViewModel, CatItem>();
            var item = Mapper.Map<CatItem>(model);
            var category = _categoryService.FindById(model.CategoryId);
            _catItemsService.EditItem(item, category);
            return Ok();
        }

        [HttpPost]
        [Route("buy")]
        public IHttpActionResult Buy(UpdateCatItemViewModel model)
        {
            Mapper.CreateMap<UpdateCatItemViewModel, CatItem>();
            var item = Mapper.Map<CatItem>(model);
            var category = _categoryService.FindById(model.CategoryId);
            _catItemsService.BuyItem(item, category);
            return Ok();
        }

        [HttpPost]
        [Route("editandbuy")]
        public IHttpActionResult EditAndBuy(UpdateCatItemViewModel model)
        {
            Mapper.CreateMap<UpdateCatItemViewModel, CatItem>();
            var item = Mapper.Map<CatItem>(model);
            var category = _categoryService.FindById(model.CategoryId);
            _catItemsService.EditAndBuyItem(item, category);
            return Ok();
        }

        [HttpPost]
        [Route("editbuyed")]
        public IHttpActionResult EditBuyed(UpdateCatItemViewModel model)
        {
            Mapper.CreateMap<UpdateCatItemViewModel, CatItem>();
            var item = Mapper.Map<CatItem>(model);
            var category = _categoryService.FindById(model.CategoryId);
            _catItemsService.EditBuyedItem(item, category);
            return Ok();
        }

        [HttpPost]
        [Route("sell")]
        public IHttpActionResult Sell(UpdateCatItemViewModel model)
        {
            Mapper.CreateMap<UpdateCatItemViewModel, CatItem>();
            var item = Mapper.Map<CatItem>(model);
            var category = _categoryService.FindById(model.CategoryId);
            _catItemsService.SellItem(item, category);
            return Ok();
        }

    }
}
