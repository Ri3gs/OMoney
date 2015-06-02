using System.Linq;
using OMoney.Data.Repositories;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Users
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IQueryable<Currency> Get(User user)
        {
            return _currencyRepository.Get(user);
        }

        public Currency Get(int id, User user)
        {
            // TODO: user validation
            return _currencyRepository.Get(id);
        }

        public Currency Create(Currency currency, User user)
        {
            currency.UserId = user.Id;
            return _currencyRepository.Create(currency);
        }

        public Currency Update(Currency currency, User user)
        {
            // TODO: user validation
            return _currencyRepository.Update(currency);
        }

        public void Delete(int id, User user)
        {
            // validation
            var currency = _currencyRepository.Get(id);
            _currencyRepository.Delete(currency);
        }
    }
}
