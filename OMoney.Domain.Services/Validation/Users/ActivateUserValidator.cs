using System.Collections.Generic;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Users
{
    public class ActivateUserValidator 
    {
        private readonly IUserRepository _userRepository;

        public ActivateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> Validate(string userId, string code)
        {
            if (userId == null) yield return "userId is null";
            if (code == null) yield return "code is null";
            if (string.IsNullOrWhiteSpace(userId)) yield return "userId is empty";
            if (string.IsNullOrWhiteSpace(code)) yield return "code is empty";
            if (_userRepository.FindById(userId) == null) yield return "userId does not exist";
        }
    }
}
