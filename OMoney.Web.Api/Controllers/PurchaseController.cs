using System;
using System.Web.Http;
//using AutoMapper;
using OMoney.Domain.Core.Entities;
//using OMoney.Domain.Services.Categories;
using OMoney.Domain.Services.PurchaseItems;
//using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    //[RoutePrefix("api/purchaseitems")]
    public class PurchaseController : ApiController
    {
        private readonly IPurchaseItemsService _purchaseItemsService;
        //private readonly ICategoryService _categoryService;

        //public PurchaseController(IPurchaseItemsService purchaseItemsService, ICategoryService categoryService)
        //{
        //    _purchaseItemsService = purchaseItemsService;
        //    _categoryService = categoryService;
        //}
        public PurchaseController(IPurchaseItemsService purchaseItemsService)
        {
            _purchaseItemsService = purchaseItemsService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_purchaseItemsService.Get());
        }

        public IHttpActionResult Get(Guid id )
        {
            return Ok(_purchaseItemsService.Get(id));
        }

        public IHttpActionResult Post(Purchase purchase)
        {
            return Ok(_purchaseItemsService.Create(purchase));
        }

        public IHttpActionResult Put(Purchase purchase)
        {
            return Ok(_purchaseItemsService.Update(purchase));
        }

        public IHttpActionResult Delete(Guid id)
        {
            Purchase purchase = _purchaseItemsService.Get(id);
            _purchaseItemsService.Delete(purchase);
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
