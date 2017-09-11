using System.Web.Http;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Currencies;
using OMoney.Web.Api.Context;

namespace OMoney.Web.Api.Controllers
{
    [Authorize]
    public class CurrencyController : ApiController
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICurrentUser _currentUser;

        public CurrencyController(ICurrencyService currencyService, ICurrentUser currentUser)
        {
            _currencyService = currencyService;
            _currentUser = currentUser;
        }

        public IHttpActionResult Get()
        {
            return Ok(_currencyService.Get(_currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_currencyService.Get(id, _currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Post(Currency currency)
        {
            return Ok(_currencyService.Create(currency, _currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Put(Currency currency)
        {
            return Ok(_currencyService.Update(currency, _currentUser.GetCurrentUser()));
        }

        public IHttpActionResult Delete(int id)
        {
            _currencyService.Delete(id, _currentUser.GetCurrentUser());
            return Ok();
        }
    }
}
