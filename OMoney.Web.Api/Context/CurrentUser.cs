using System.Web;
using Microsoft.AspNet.Identity;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Users;

namespace OMoney.Web.Api.Context
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IUserService _userService;

        public CurrentUser(IUserService userService)
        {
            _userService = userService;
        }

        public User GetCurrentUser()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return _userService.FindById(userId);
        }
    }
}