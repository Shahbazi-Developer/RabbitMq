using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Domain.Common.DomainBusiness
{
    public class DomainBusinessError
    {
        public DomainBusinessError(string error)
        {
            Message = error;
            Parameters = Array.Empty<string>();
        }

        public DomainBusinessError(string error, params string[] parameters)
        {
            Message = error;
            Parameters = parameters;
        }

        public string Message { get; set; } = null!;
        public string[] Parameters { get; set; }
    }
}
