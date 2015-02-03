using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public class UserRepository : IUserRepository, IDisposable
    {

        private readonly AuthContext _authDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository()
        {
            _authDbContext = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_authDbContext));

            var provider = new DpapiDataProtectionProvider("OMoney");
            _userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(provider.Create("EmailConfirmation"));

            
        }


        public void Create(User user, string password)
        {
            var userDb = new IdentityUser
            {
                UserName = user.Name,
                Email = user.Email
            };

            _userManager.Create(userDb, password);

        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            var identityUser = _userManager.FindByEmail(email);
            if (identityUser != null)
            {
                return new User
                {
                    Email = identityUser.Email
                };
            }
            return null;
        }

        public User FindUser(string email, string password)
        {
            var identityUser = _userManager.Find(email, password);
            if (identityUser != null)
            {
                return new User
                {
                    Email = identityUser.Email
                };
            }
            return null;
        }

        public User FindById(string userId)
        {
            var identityUser = _userManager.FindById(userId);
            if (identityUser != null)
            {
                return new User
                {
                    Email = identityUser.Email,
                };
            }
            return null;
        }

        public string GetId(string email)
        {
            var identityUser = _userManager.FindByEmail(email);
            if (identityUser != null)
            {
                return identityUser.Id;
            }
            return null;
        }

        public string GenerateEmailToken(string userId)
        {
            var identityUser = _userManager.FindById(userId);
            if (identityUser != null)
            {
                return _userManager.GenerateEmailConfirmationToken(userId);
            }

            return null;
        }

        public bool ConfirmEmail(string userId, string code)
        {
            var result = _userManager.ConfirmEmail(userId, code);
            return result.Succeeded;
        }

        public string GeneratePwdToken(string email)
        {
            var identityUser = _userManager.FindByEmail(email);
            var token = _userManager.GeneratePasswordResetToken(identityUser.Id);
            var address = string.Format("userId={0}&code={1}", HttpUtility.UrlEncode(identityUser.Id), HttpUtility.UrlEncode(token));
            return address;
        }

        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            var result = _userManager.ChangePassword(_userManager.FindByEmail(email).Id, oldPassword, newPassword);
            return result.Succeeded;

        }

        public bool ResetPassword_(string userId, string code, string newPassword)
        {
            var result = _userManager.ResetPassword(userId, code, newPassword);
            return result.Succeeded;
        }

        public void Dispose()
        {
            _authDbContext.Dispose();
            _userManager.Dispose();
        }
    }
}
