using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Services.Notifications;
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
                SendConfirmationEmailForNewUser(user);

                transaction.Complete();
            }
        }

        public void Activate(string userId, string code)
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

        public void ChangePassword(string email, string oldPassword, string newPassword, string confirmNewPassword)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new ChangePasswordValidator(_userRepository);
                var validationErrors = validator.Validate(email, oldPassword, newPassword, confirmNewPassword).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                if (_userRepository.ChangePassword(email, oldPassword, newPassword))
                {
                    transaction.Complete();
                }
                else
                {
                    throw new DomainEntityValidationException { ValidationErrors = new List<string> { "Cant change password. Try again." } };
                }
            }
        }

        public void ResetPassword(string userId, string code, string newPassword, string confirmNewPassword)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new ResetPasswordValidator(_userRepository);
                var validationErrors = validator.Validate(userId, code, newPassword, confirmNewPassword).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                if (_userRepository.ResetPassword_(userId, code, newPassword))
                {
                    transaction.Complete();
                }
                else
                {
                    throw new DomainEntityValidationException { ValidationErrors = new List<string>{ "Cant reset password. Try again." }};
                }
            }
        }

        public void SendResetLink(string email)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new SendResetLinkValidator(_userRepository);
                var validationErrors = validator.Validate(email).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                SendResetPasswordLink(email);

                transaction.Complete();
            }
        }

        private static IEnumerable<string> Validate(User user, IDomainEntityValidator<User> validator)
        {
            return validator.Validate(user);
        }

        private void SendResetPasswordLink(string email)
        {
            var id = _userRepository.GetId(email);
            var code = _userRepository.GeneratePwdToken(id);
            var link = _notificationService.BuildPasswordResetLink(id, code);
            var message = _notificationService.BuildResetPasswordNotificationMessage(link, email);

            _notificationService.SendEmail(message);
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