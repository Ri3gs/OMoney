using System.Web.Http;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Validation;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    [RoutePrefix("api/notification")]
    public class NotificationController : ApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        [Route("restorepassword")]
        public IHttpActionResult RestorePassword(RestorePasswordViewModel model)
        {
            try
            {
                _notificationService.SendResetPasswordEmail(model.Email);
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
        [Route("emailconfirmationexisting")]
        public IHttpActionResult ConfirmEmail(RestorePasswordViewModel model)
        {
            try
            {
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


    }
}