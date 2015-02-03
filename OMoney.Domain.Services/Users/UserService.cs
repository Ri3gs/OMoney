using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Notifications.NotificationMessages;
using OMoney.Domain.Services.Validation;
using OMoney.Domain.Services.Validation.Users;

namespace OMoney.Domain.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;

        public UserService(IUserRepository userRepository, INotificationService notificationService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public void Create(User user, string password, string confrimPassword)
        {
            using (var transaction = new TransactionScope())
            {
                var validationErrors = Validate(user, new CreateNewUserValidator(_userRepository, password, confrimPassword)).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                _userRepository.Create(user, password);

                transaction.Complete();
            }

            SendConfirmationEmailForNewUser(user);
        }

        public bool Activate(string userId, string code)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new ActivateUserValidator(_userRepository);
                var validationErrors = validator.Validate(userId, code).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException {ValidationErrors = validationErrors};

                if (_userRepository.ConfirmEmail(userId, code))
                {
                    transaction.Complete();
                }
                else
                {
                    throw new DomainEntityValidationException { ValidationErrors = new List<string>{ "Cant confirm your email. Try again." }};
                }
            }
            return true;
        }

        public void Update(User user)
        {
            using (var transaction = new TransactionScope())
            {
                var validationErrors = Validate(user, new UpdateUserValidator(_userRepository)).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                _userRepository.Update(user);

                transaction.Complete();
            }
        }

        public void Delete(User user)
        {
            using (var transaction = new TransactionScope())
            {
                var validationErrors = Validate(user, new DeleteUserValidator(_userRepository)).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                _userRepository.Delete(user);

                transaction.Complete();
            }
        }

        public User FindUser(string email, string password)
        {
            return null;
        }

        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            return _userRepository.ChangePassword(email, oldPassword, newPassword);
        }

        public bool ResetPassword(string userId, string code, string newPassword)
        {
            return _userRepository.ResetPassword_(userId, code, newPassword);
        }

        public void SendResetLink(string email)
        {
            _notificationService.SendEmail(new EmailNotificationMessage { Subject = "Reset password from OMoney", Body = string.Format("Please follow this link to reset your password: <a href='{0}'>link</a>", GeneratePwdResetLink(email)), Destination = email});
        }

        private string GeneratePwdResetLink(string email)
        {
            var code = _userRepository.GeneratePwdToken(email);
            return string.Format("http://localhost:4598/#/resetpassword?{0}", code);
        }

        private static IEnumerable<string> Validate(User user, IDomainEntityValidator<User> validator)
        {
            return validator.Validate(user);
        }

        private void SendConfirmationEmailForNewUser(User user)
        {
            var id = _userRepository.GetId(user.Email);
            var code = _userRepository.GenerateEmailToken(id);
            var link = _notificationService.BuildEmailConfirmationLink(id, code);
            var message = _notificationService.BuildConfirmEmailForNewUserNotificationMessage(link, user.Email);

            _notificationService.SendEmail(message);
        }
    }
}