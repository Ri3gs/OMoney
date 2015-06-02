using System.Linq;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Users
{
    public interface IAccountService
    {
        IQueryable<Account> Get(User user);
        Account Get(int id, User user);
        Account Create(Account account, User user);
        Account Update(Account account, User user);
        void Delete(int id, User user);
        //void Create(Account account, string email);
        //void Delete(int id, string email);
        //void Update(Account account, string email);
        //List<Account> GetAccounts(string email, string whoWantsToKnowEmail);
        //Account FindById(int id, string email);
    }
}
