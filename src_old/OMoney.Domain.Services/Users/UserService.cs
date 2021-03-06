﻿using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using OMoney.Data.Repositories;
using OMoney.Data.Repositories.Users;
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

                var repoErrors = _userRepository.Create(user, password);
                if (repoErrors == null)
                {
                    _notificationService.SendConfirmationEmailForNewUser(user);
                    transaction.Complete();
                }
                else
                {
                    throw new DomainEntityValidationException { ValidationErrors = repoErrors};
                }
            }
        }

        public void Activate(string userId, string code)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new ActivateUserValidator(_userRepository);
                var validationErrors = validator.Validate(userId, code).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException {ValidationErrors = validationErrors};

                var repoErrors = _userRepository.ConfirmEmail(userId, code);
                if (repoErrors == null)
                {
                    transaction.Complete();
                }
                else
                {
                    throw new DomainEntityValidationException { ValidationErrors = repoErrors };
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

        public void UpdateToGold(string email)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new SendResetLinkValidator(_userRepository);
                var validationErrors = validator.Validate(email).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                _userRepository.UpdateToGold(email);

                transaction.Complete();
            }
        }

        public void RemoveGold(string email)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new SendResetLinkValidator(_userRepository);
                var validationErrors = validator.Validate(email).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                _userRepository.RemoveGold(email);

                transaction.Complete();
            }
        }

        public User FindUser(string email, string password)
        {
            var validator = new FindUserValidator();
            var validationErrors = validator.Validate(email, password).ToList();
            if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

            return _userRepository.FindUser(email, password);
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public User FindById(string id)
        {
            return _userRepository.FindById(id);
        }

        public void ChangePassword(string email, string oldPassword, string newPassword, string confirmNewPassword)
        {
            using (var transaction = new TransactionScope())
            {
                var validator = new ChangePasswordValidator(_userRepository);
                var validationErrors = validator.Validate(email, oldPassword, newPassword, confirmNewPassword).ToList();
                if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

                var repoErrors = _userRepository.ChangePassword(email, oldPassword, newPassword);
                if (repoErrors == null)
                {
                    transaction.Complete();
                }
                else
                {
                    throw new DomainEntityValidationException { ValidationErrors = repoErrors };
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

                var repoErrors = _userRepository.ResetPassword(userId, code, newPassword);

                if (repoErrors == null)
                {
                    transaction.Complete();
                }
                else
                {
                    throw new DomainEntityValidationException { ValidationErrors = repoErrors };
                }
            }
        }

        public bool CheckEmail(string email)
        {
            var validator = new SendResetLinkValidator(_userRepository);
            var validationErrors = validator.Validate(email).ToList();
            if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };
            return _userRepository.CheckEmail(email);
        }

        private static IEnumerable<string> Validate(User user, IDomainEntityValidator<User> validator)
        {
            return validator.Validate(user);
        }
    }
}