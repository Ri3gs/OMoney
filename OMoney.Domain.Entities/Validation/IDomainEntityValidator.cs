using System.Collections.Generic;

namespace OMoney.Domain.Core.Validation
{
    public interface IDomainEntityValidator<T> where T : class
    {
        IEnumerable<string> Validate(T entity);
    }
}
