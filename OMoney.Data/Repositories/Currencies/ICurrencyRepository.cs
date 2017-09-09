using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories.Currencies
{
    public interface ICurrencyRepository
    {
        IQueryable<Currency> Get(User user);
        Currency Get(int id);
        Currency Create(Currency currency);
        Currency Update(Currency currency);
        void Delete(Currency currency);
    }
}
