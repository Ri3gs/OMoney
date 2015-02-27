using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public interface IAccountRepository
    {
        void CreateAccount(Account account);
        List<Account> GetAccounts(User user);
        void DeleteAccount(Account account);
        void UpdateAccount(Account account);
        Account FindById(int id);
    }
}
