using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Domain.Common.DomainBusiness
{
    public class DomainBusinessResult
    {
        public List<DomainBusinessError> Errors { get; set; } = new();
        public bool IsSuccess => !Errors.Any();
        public DomainBusinessError? FirstError => Errors.FirstOrDefault();

        public void AddError(DomainBusinessError? error)
        {
            if (error is not null)
                Errors.Add(error);
        }

        public void AddError(string error, params string[] parameters)
        {
            if (!string.IsNullOrWhiteSpace(error))
                Errors.Add(new DomainBusinessError(error, parameters));
        }
    }

    public class DomainBusinessResult<TResult> : DomainBusinessResult
    {
        public TResult? Result { get; set; }
    }
}
