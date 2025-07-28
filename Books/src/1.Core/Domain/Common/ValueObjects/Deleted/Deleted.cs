using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.ValueObjects;

namespace Book.Core.Domain.Common.ValueObjects.Deleted
{
    public class Deleted : BaseValueObject<Deleted>
    {
        #region Constructors

        public Deleted(bool value)
        {
            Value = value;
        }

        #endregion

        #region Properties

        public bool Value { get; private set; }

        #endregion

        #region Methods

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Deleted(bool v)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
