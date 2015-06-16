using System.Web.Http;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Purchases;

namespace OMoney.Web.Api.Controllers
{
    [Authorize]
    public class PurchaseController : ApiController
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_purchaseService.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_purchaseService.Get(id));
        }

        public IHttpActionResult Post(Purchase purchase)
        {
            return Ok(_purchaseService.Create(purchase));
        }

        public IHttpActionResult Put(Purchase purchase)
        {
            return Ok(_purchaseService.Update(purchase));
        }

        public IHttpActionResult Delete(int id)
        {
            _purchaseService.Delete(id);
            return Ok();
        }

    //    [HttpPost]
    //    [Route("create")]
    //    public IHttpActionResult Post(CreatePurchaseViewModel model)
    //    {
    //        Mapper.CreateMap<CreatePurchaseViewModel, Purchase>();
    //        var purchase = Mapper.Map<Purchase>(model);
    //        var category = _categoryService.FindById(model.CategoryId);
    //        _purchaseItemsService.Create(purchase, category);
    //        return Ok();
    //    }

    //    [HttpGet]
    //    [Route("delete")]
    //    public IHttpActionResult Delete(int id)
    //    {
    //        _purchaseItemsService.Delete(id);
    //        return Ok();
    //    }

    //    [HttpPost]
    //    [Route("edit")]
    //    public IHttpActionResult Put(UpdatePurchaseViewModel model)
    //    {
    //        Mapper.CreateMap<UpdatePurchaseViewModel, Purchase>();
    //        var purchase = Mapper.Map<Purchase>(model);
    //        var category = _categoryService.FindById(model.CategoryId);
    //        _purchaseItemsService.EditItem(purchase, category);
    //        return Ok();
    //    }

    //    [HttpPost]
    //    [Route("buy")]
    //    public IHttpActionResult Buy(UpdatePurchaseViewModel model)
    //    {
    //        Mapper.CreateMap<UpdatePurchaseViewModel, Purchase>();
    //        var purchase = Mapper.Map<Purchase>(model);
    //        var category = _categoryService.FindById(model.CategoryId);
    //        _purchaseItemsService.BuyItem(purchase, category);
    //        return Ok();
    //    }

    //    [HttpPost]
    //    [Route("editandbuy")]
    //    public IHttpActionResult EditAndBuy(UpdatePurchaseViewModel model)
    //    {
    //        Mapper.CreateMap<UpdatePurchaseViewModel, Purchase>();
    //        var purchase = Mapper.Map<Purchase>(model);
    //        var category = _categoryService.FindById(model.CategoryId);
    //        _purchaseItemsService.EditAndBuyItem(purchase, category);
    //        return Ok();
    //    }

    //    [HttpPost]
    //    [Route("editbuyed")]
    //    public IHttpActionResult EditBuyed(UpdatePurchaseViewModel model)
    //    {
    //        Mapper.CreateMap<UpdatePurchaseViewModel, Purchase>();
    //        var purchase = Mapper.Map<Purchase>(model);
    //        var category = _categoryService.FindById(model.CategoryId);
    //        _purchaseItemsService.EditBuyedItem(purchase, category);
    //        return Ok();
    //    }

    //    [HttpPost]
    //    [Route("sell")]
    //    public IHttpActionResult Sell(UpdatePurchaseViewModel model)
    //    {
    //        Mapper.CreateMap<UpdatePurchaseViewModel, Purchase>();
    //        var purchase = Mapper.Map<Purchase>(model);
    //        var category = _categoryService.FindById(model.CategoryId);
    //        _purchaseItemsService.SellItem(purchase, category);
    //        return Ok();
    //    }
    }
}
