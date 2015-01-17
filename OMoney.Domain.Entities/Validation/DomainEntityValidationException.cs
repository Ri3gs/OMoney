using System;
using System.Collections.Generic;

namespace OMoney.Domain.Core.Validation
{
    public class DomainEntityValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }
    }
}
