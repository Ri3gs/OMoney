using System;
using System.Web.Http;
using AutoMapper;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Users;
using OMoney.Domain.Services.Validation;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;

        public UserController(IUserService userService, INotificationService notificationService)
        {
            _userService = userService;
            _notificationService = notificationService;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("signup")]
        public IHttpActionResult Signup(UserViewModel userModel)
        {
            try
            {
                Mapper.CreateMap<UserViewModel, User>();
                var user = Mapper.Map<User>(userModel);
                user.UserName = userModel.Email;
                user.GoldExpirationTime = DateTime.Now;
                _userService.Create(user, userModel.Password, userModel.ConfirmPassword);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationErrors", validationError);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginViewModel model)
        {
            return BadRequest(ModelState);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("activate")]
        public IHttpActionResult Activate(EmailConfirmationViewModel model)
        {
            try
            {
                _userService.Activate(model.UserId, model.Code);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationErrors", validationError);
                }
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost]
        [Route("changepassword")]
        public IHttpActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                _userService.ChangePassword(model.Email, model.OldPassword, model.NewPassword, model.ConfirmNewPassword);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationErrors", validationError);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("restorepassword")]
        public IHttpActionResult RestorePassword(RestorePasswordViewModel model)
        {
            try
            {
                _notificationService.SendResetPasswordEmail(model.Email);
                //_userService.SendResetLink(model.Email);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationErrors", validationError);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("resetpassword")]
        public IHttpActionResult ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                _userService.ResetPassword(model.userId, model.code, model.newPassword, model.confirmNewPassword);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationErrors", validationError);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("checkemail")]
        public IHttpActionResult CheckEmail(string email)
        {
            if (_userService.CheckEmail(email))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("confirmemail")]
        public IHttpActionResult ConfirmEmail(RestorePasswordViewModel model)
        {
            try
            {
                //_userService.SendConfirmationLink(model.Email);
                _notificationService.SendConfirmationEmailForExistingUser(model.Email);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationErrors", validationError);
                }
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost]
        [Route("givegold")]
        public IHttpActionResult GiveGold(GiveGoldViewModel model)
        {
            try
            {
                _userService.UpdateToGold(model.Email);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationErrors", validationError);
                }
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost]
        [Route("removegold")]
        public IHttpActionResult RemoveGold(GiveGoldViewModel model)
        {
            try
            {
                _userService.RemoveGold(model.Email);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationErrors", validationError);
                }
            }

            return BadRequest(ModelState);
        }
    }
}