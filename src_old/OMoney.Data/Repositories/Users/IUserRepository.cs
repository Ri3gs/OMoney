﻿using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Repositories.Users
{
    public interface IUserRepository
    {
        List<string> Create(User user, string password);
        void Update(User user);
        void Delete(User user);
        void UpdateToGold(string email);
        void RemoveGold(string email);

        List<string> ConfirmEmail(string userId, string code);
        List<string> ChangePassword(string email, string oldPassword, string newPassword);
        List<string> ResetPassword(string userId, string code, string newPassword);
        bool CheckEmail(string email);
        
        User FindUser(string email, string password);
        User FindById(string userId);
        User GetByEmail(string email);
        string GetId(string email);


        string GenerateEmailToken(string userId);
        string GeneratePwdToken(string userId);
    }
}
