using System;
using System.Linq;
using OMoney.Data.Repositories;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Users
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IQueryable<Account> Get(User user)
        {
            // TODO: validation for user
            return _accountRepository.Get();
        }

        public Account Get(int id, User user)
        {
            // TODO: validation for user
            return _accountRepository.Get(id);
        }

        public Account Create(Account account, User user)
        {
            account.CreatedAt = DateTime.Now;
            account.UpdatedAt = DateTime.Now;
            account.UserId = user.Id;
            return _accountRepository.Create(account);
        }

        public Account Update(Account account, User user)
        {
            account.UpdatedAt = DateTime.Now;
            return _accountRepository.Update(account);
        }

        public void Delete(int id, User user)
        {
            var account = _accountRepository.Get(id);
            _accountRepository.Delete(account);
        }

        //private readonly IAccountRepository _accountRepository;
        //private readonly IUserRepository _userRepository;

        //public AccountService(IAccountRepository accountRepository, IUserRepository userRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _userRepository = userRepository;
        //}

        //public void Create(Account account, string email)
        //{
        //    using (var transaction = new TransactionScope())
        //    {
        //        var validator = new CreateNewAccountValidator(_userRepository, _accountRepository);
        //        var validationErrors = validator.Validate(account, email).ToList();
        //        if (validationErrors.Any()) throw new DomainEntityValidationException {ValidationErrors = validationErrors};

        //        try
        //        {
        //            var user = _userRepository.GetByEmail(email);
        //            account.UserId = user.Id;
        //            account.CreatedAt = DateTime.Now;
        //            account.UpdatedAt = DateTime.Now;
        //            _accountRepository.CreateAccount(account);
        //        }
        //        catch (Exception exception)
        //        {
        //            throw new DomainEntityValidationException { ValidationErrors = new List<string>{exception.ToString() }};
        //        }
        //        transaction.Complete();
        //    }
        //}

        //public void Delete(int id, string email)
        //{
        //    using (var transaction = new TransactionScope())
        //    {
        //        var validator = new DeleteAccountValidator(_userRepository, _accountRepository);
        //        var validationErrors = validator.Validate(id, email).ToList();
        //        if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

        //        try
        //        {
        //            var account = _accountRepository.FindById(id);
        //            _accountRepository.DeleteAccount(account);
        //        }
        //        catch (Exception exception)
        //        {
        //            throw new DomainEntityValidationException { ValidationErrors = new List<string> { exception.ToString() } };
        //        }
        //        transaction.Complete();
        //    }
        //}

        //public void Update(Account account, string email)
        //{
        //    using (var transaction = new TransactionScope())
        //    {
        //        var validator = new UpdateAccountValidator(_userRepository, _accountRepository);
        //        var validationErrors = validator.Validate(account, email).ToList();
        //        if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

        //        try
        //        {
        //            var accountDb = _accountRepository.FindById(account.Id);
        //            accountDb.Amount = account.Amount;
        //            accountDb.Name = account.Name;
        //            accountDb.Comments = account.Comments;
        //            accountDb.UpdatedAt = DateTime.Now;
        //            accountDb.AccountCurrency = account.AccountCurrency;
        //            accountDb.AccountType = account.AccountType;

        //            _accountRepository.UpdateAccount(accountDb);
        //        }
        //        catch (Exception exception)
        //        {
        //            throw new DomainEntityValidationException { ValidationErrors = new List<string> { exception.ToString() } };
        //        }
        //        transaction.Complete();
        //    }
        //}

        //public List<Account> GetAccounts(string email, string whoWantsToKnowEmail)
        //{
        //    var validator = new GetAccountsValidator(_userRepository, _accountRepository);
        //    var validationErrors = validator.Validate(email, whoWantsToKnowEmail).ToList();
        //    if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };
            
        //    try
        //    {
        //        var user = _userRepository.GetByEmail(email);
        //        return _accountRepository.GetAccounts(user);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new DomainEntityValidationException { ValidationErrors = new List<string> { exception.ToString() } };
        //    }
        //}

        //public Account FindById(int id, string email)
        //{
        //    var validator = new FindByIdAccountValidator(_userRepository, _accountRepository);
        //    var validationErrors = validator.Validate(id, email).ToList();
        //    if (validationErrors.Any()) throw new DomainEntityValidationException { ValidationErrors = validationErrors };

        //    try
        //    {
        //        return _accountRepository.FindById(id);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new DomainEntityValidationException { ValidationErrors = new List<string> { exception.ToString() } };
        //    }
        //}
    }
}
