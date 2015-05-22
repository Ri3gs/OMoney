using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Users
{
    public interface IAccountService
    {
        IQueryable<Account> Get();
        Account Get(int id);
        Account Create(Account account);
        Account Update(Account account);
        void Delete(Account account);
        //void Create(Account account, string email);
        //void Delete(int id, string email);
        //void Update(Account account, string email);
        //List<Account> GetAccounts(string email, string whoWantsToKnowEmail);
        //Account FindById(int id, string email);
    }
}
