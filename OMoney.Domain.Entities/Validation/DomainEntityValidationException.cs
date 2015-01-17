using System;
using System.Collections.Generic;

namespace OMoney.Domain.Entities.Validation
{
    public class DomainEntityValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }
    }
}
