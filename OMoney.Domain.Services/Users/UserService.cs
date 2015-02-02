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
            _notificationService.SendEmail(BuildNewUserNotificationMessage(user));
        }

        public bool Activate(string userId, string code)
        {
            return _userRepository.ConfirmEmail(userId, code);
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

        private EmailNotificationMessage BuildNewUserNotificationMessage(User user)
        {
            return new EmailNotificationMessage {Subject = "Wellcome to OMoney!", Body = string.Format("Please follow this link: <a href='{0}'>link</a>", GenerateActivationLink(user)), Destination = user.Email};
        }

        private string GenerateActivationLink(User user)
        {
            var code = _userRepository.GenerateEmailToken(user.Email);
            return string.Format("http://localhost:4586/api/user/activate?{0}", code);
        }

        private static IEnumerable<string> Validate(User user, IDomainEntityValidator<User> validator)
        {
            return validator.Validate(user);
        }
    }
}