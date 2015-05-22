using System.Web.Http;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Users;

namespace OMoney.Web.Api.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_accountService.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_accountService.Get(id));
        }

        public IHttpActionResult Post(Account account)
        {
            return Ok(_accountService.Create(account));
        }

        public IHttpActionResult Put(Account account)
        {
            return Ok(_accountService.Update(account));
        }

        public IHttpActionResult Delete(Account account)
        {
            try
            {
                _accountService.Delete(account);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //[HttpPost]
        //[Route("create")]
        //public IHttpActionResult CreateAccount(AccountViewModel accountViewModel)
        //{
        //    try
        //    {
        //        Mapper.CreateMap<AccountViewModel, Account>();
        //        var account = Mapper.Map<Account>(accountViewModel);
        //        _accountService.Create(account, accountViewModel.Email);
        //        return Ok();
        //    }
        //    catch (DomainEntityValidationException validationException)
        //    {
        //        foreach (var validationError in validationException.ValidationErrors)
        //        {
        //            ModelState.AddModelError("validationErrors", validationError);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpPost]
        //[Route("list")]
        //public IHttpActionResult List(AccountListViewModel model)
        //{
        //    try
        //    {
        //        if (Request.Headers.Contains("userName"))
        //        {
        //            var accounts = _accountService.GetAccounts(model.Email, Request.Headers.GetValues("userName").First());
        //            return Ok(accounts);
        //        }
        //        ModelState.AddModelError("validationErrors", "You can't view other ppl accounts.");
        //        return BadRequest(ModelState);
        //    }
        //    catch (DomainEntityValidationException validationException)
        //    {
        //        foreach (var validationError in validationException.ValidationErrors)
        //        {
        //            ModelState.AddModelError("validationErrors", validationError);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpPost]
        //[Route("update")]
        //public IHttpActionResult Update(AccountUpdateViewModel model)
        //{
        //    try
        //    {
        //        Mapper.CreateMap<AccountUpdateViewModel, Account>();
        //        var account = Mapper.Map<Account>(model);
        //        _accountService.Update(account, model.Email);
        //        return Ok();
        //    }
        //    catch (DomainEntityValidationException validationException)
        //    {
        //        foreach (var validationError in validationException.ValidationErrors)
        //        {
        //            ModelState.AddModelError("validationErrors", validationError);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpPost]
        //[Route("delete")]
        //public IHttpActionResult Delete(DeleteAccountViewModel model)
        //{
        //    try
        //    {
        //        _accountService.Delete(model.Id, model.Email);
        //        return Ok();
        //    }
        //    catch (DomainEntityValidationException validationException)
        //    {
        //        foreach (var validationError in validationException.ValidationErrors)
        //        {
        //            ModelState.AddModelError("validationErrors", validationError);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpPost]
        //[Route("getaccount")]
        //public IHttpActionResult GetAccount(GetAccountViewModel model)
        //{
        //    try
        //    {
        //        if (Request.Headers.Contains("userName"))
        //        {
        //            var account = _accountService.FindById(model.Id, Request.Headers.GetValues("userName").First());
        //            return Ok(account);
        //        }
        //        ModelState.AddModelError("validationErrors", "You can't view other ppl account.");
        //        return BadRequest(ModelState);
        //    }
        //    catch (DomainEntityValidationException validationException)
        //    {
        //        foreach (var validationError in validationException.ValidationErrors)
        //        {
        //            ModelState.AddModelError("validationErrors", validationError);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}
    }
}
