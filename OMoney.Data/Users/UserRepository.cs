using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public class UserRepository : IUserRepository
    {

        private readonly AuthContext _authDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository()
        {
            _authDbContext = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_authDbContext));
        }


        public void Create(User user, string password)
        {
            var userDb = new IdentityUser
            {
                UserName = user.Email,
                Email = user.Email,
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
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            _authDbContext.Dispose();
            _userManager.Dispose();
        }
    }
}
