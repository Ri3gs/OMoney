﻿using System.Web.Http;
using AutoMapper;
using OMoney.Domain.Core.Entities;
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

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginViewModel model)
        {
            return BadRequest(ModelState);
        }
    }
}