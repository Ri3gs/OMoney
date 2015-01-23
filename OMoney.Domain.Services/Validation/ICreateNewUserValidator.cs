using System.Collections.Generic;

namespace OMoney.Domain.Services.Validation
{
    public interface ICreateNewUserValidator<T> where T: class 
    {
        IEnumerable<string> Validate(T entity, string password, string confirmPassword);
    }
}
