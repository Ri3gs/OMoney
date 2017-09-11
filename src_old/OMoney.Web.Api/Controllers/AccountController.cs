using System.Web.Http;
using System.Web.Http.Cors;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Accounts;
using OMoney.Web.Api.Context;

namespace OMoney.Web.Api.Controllers
{
    [Authorize]
    [EnableCors("http://localhost:4598", "*", "*")]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly ICurrentUser _currentUser;

        public AccountController(IAccountService accountService, ICurrentUser currentUser)
        {
            _accountService = accountService;
            _currentUser = currentUser;
        }

        public IHttpActionResult Get()
        {
            return Ok(_accountService.Get(_currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_accountService.Get(id, _currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Post(Account account)
        {
            return Ok(_accountService.Create(account, _currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Put(Account account)
        {
            return Ok(_accountService.Update(account, _currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _accountService.Delete(id, _currentUser.GetCurrentUser());
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
