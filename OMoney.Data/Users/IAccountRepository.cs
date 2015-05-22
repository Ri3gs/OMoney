using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public interface IAccountRepository
    {
        IQueryable<Account> Get();
        Account Get(int id);
        Account Create(Account account);
        Account Update(Account account);
        void Delete(Account account);
        //void CreateAccount(Account account);
        //List<Account> GetAccounts(User user);
        //void DeleteAccount(Account account);
        //void UpdateAccount(Account account);
        //Account FindById(int id);
    }
}
