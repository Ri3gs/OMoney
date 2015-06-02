using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories
{
    public interface IAccountRepository
    {
        IQueryable<Account> Get();
        Account Get(int id);
        Account Create(Account account);
        Account Update(Account account);
        void Delete(Account account);
    }
}
