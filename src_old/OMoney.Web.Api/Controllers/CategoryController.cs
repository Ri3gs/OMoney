using System.Web.Http;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Categories;

namespace OMoney.Web.Api.Controllers
{

    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public IHttpActionResult Get()
        {
            return Ok(_categoryService.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_categoryService.Get(id));
        }

        public IHttpActionResult Post(Category category)
        {
            return Ok(_categoryService.Create(category));
        }

        public IHttpActionResult Put(Category category)
        {
            return Ok(_categoryService.Update(category));
        }

        public IHttpActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }


        //[HttpPost]
        //[Route("create")]
        //public IHttpActionResult Create(CreateCategoryViewModel model)
        //{
        //    Mapper.CreateMap<CreateCategoryViewModel, Category>();
        //    var category = Mapper.Map<Category>(model);
        //    _categoryService.Create(category);
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("update")]
        //public IHttpActionResult Update(UpdateCategoryViewModel model)
        //{
        //    Mapper.CreateMap<UpdateCategoryViewModel, Category>();
        //    var category = Mapper.Map<Category>(model);
        //    _categoryService.Update(category);
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("delete")]
        //public IHttpActionResult Delete(int id)
        //{
        //    _categoryService.Delete(id);
        //    return Ok();
        //}
    }
}
