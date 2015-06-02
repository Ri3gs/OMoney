using System.Web;
using Microsoft.AspNet.Identity;
using OMoney.Data.Repositories;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Users;

namespace OMoney.Web.Api.Context
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IUserRepository _userRepository;

        public CurrentUser()
        {
            _userRepository = new UserRepository();
        }

        public User GetCurrentUser()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return _userRepository.FindById(userId);
        }
    }
}