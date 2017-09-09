using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Currencies
{
    public interface ICurrencyService
    {
        IQueryable<Currency> Get(User user);
        Currency Get(int id, User user);
        Currency Create(Currency currency, User user);
        Currency Update(Currency currency, User user);
        void Delete(int id, User user);
    }
}
