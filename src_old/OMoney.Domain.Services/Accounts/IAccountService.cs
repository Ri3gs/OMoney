using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Accounts
{
    public interface IAccountService
    {
        IQueryable<Account> Get(User user);
        Account Get(int id, User user);
        Account Create(Account account, User user);
        Account Update(Account account, User user);
        void Delete(int id, User user);
    }
}
