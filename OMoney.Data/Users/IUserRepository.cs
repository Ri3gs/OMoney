using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public interface IUserRepository
    {
        List<string> Create(User user, string password);
        void Update(User user);
        void Delete(User user);

        List<string> ConfirmEmail(string userId, string code);
        List<string> ChangePassword(string email, string oldPassword, string newPassword);

        List<string> ResetPassword_(string userId, string code, string newPassword);
        
        User FindUser(string email, string password);
        User FindById(string userId);
        User GetByEmail(string email);
        string GetId(string email);


        string GenerateEmailToken(string userId);
        string GeneratePwdToken(string userId);
    }
}
