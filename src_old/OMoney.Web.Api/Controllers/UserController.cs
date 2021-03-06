﻿using System;
using System.Web.Http;
using AutoMapper;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Users;
using OMoney.Domain.Services.Validation;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("signup")]
        public IHttpActionResult Signup(UserViewModel userModel)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UserViewModel, User>());
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