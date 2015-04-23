using System.Web.Http;
using AutoMapper;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Categories;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(CreateCategoryViewModel model)
        {
            Mapper.CreateMap<CreateCategoryViewModel, Category>();
            var category = Mapper.Map<Category>(model);
            _categoryService.Create(category);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update(UpdateCategoryViewModel model)
        {
            Mapper.CreateMap<UpdateCategoryViewModel, Category>();
            var category = Mapper.Map<Category>(model);
            _categoryService.Update(category);
            return Ok();
        }

        [HttpGet]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}
