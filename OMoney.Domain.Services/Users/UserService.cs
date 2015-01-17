using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using OMoney.Data.Users;
using OMoney.Domain.Core.Validation;
using OMoney.Domain.Core.Validation.Users;
using OMoney.Domain.Entities.Entities;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Notifications.NotificationMessages;

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

        public void Create(User user)
        {
            using (var transaction = new TransactionScope())
            {
                var validationErrors = Validate(user, new CreateNewUserValidator()).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                _userRepository.Create(user);
                _notificationService.SendEmail(BuildNewUserNotificationMessage(user));

                transaction.Complete();
            }
        }

        public void Activate(User user)
        {
            throw new NotImplementedException();
        }

        private EmailNotificationMessage BuildNewUserNotificationMessage(User user)
        {
            return new EmailNotificationMessage {Subject = "Wellcome to OMoney!", Body = string.Format("Please follow this link: <a href='{0}'>link</a>", GenerateActivationLink(user))};
        }

        private string GenerateActivationLink(User user)
        {
            return string.Format("http://omoney.com.ua/activate/{0}", user.Email);
        }

        public void Update(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new System.NotImplementedException();
        }

        private IEnumerable<string> Validate(User user, IDomainEntityValidator<User> validator)
        {
            return validator.Validate(user);
        }
    }
}