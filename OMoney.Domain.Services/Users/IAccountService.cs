using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Users
{
    public interface IAccountService
    {
        void Create(Account account, string email);
        void Delete(int id, string email);
        void Update(Account account, string email);
        List<Account> GetAccounts(string email, string whoWantsToKnowEmail);
        Account FindById(int id, string email);
    }
}
