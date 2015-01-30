using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Ninject.Modules;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Users;
using OMoney.Domain.Services.Validation;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public IHttpActionResult Register(UserViewModel userModel)
        {
            try
            {
                Mapper.CreateMap<UserViewModel, User>();
                var user = Mapper.Map<User>(userModel);
                user.Name = userModel.Email;
                _userService.Create(user, userModel.Password, userModel.ConfirmPassword);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationError", validationError);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("register")]
        public IHttpActionResult Register()
        {
            return Ok();
        }

    }

    public class UserServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<INotificationService>().To<NotificationService>();
        }
    }
}