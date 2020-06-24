using System.Collections.Generic;
using System.Linq;

namespace Inventory.Domain.SharedKernel
{
    public abstract class ValueObject<T> where T : ValueObject<T> 
    {
        protected abstract IEnumerable<object> PropertiesToCheckForEquality();

        protected bool Equals(ValueObject<T> other) => PropertiesToCheckForEquality().SequenceEqual(other.PropertiesToCheckForEquality());

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return false;
            }

            return obj.GetType() == this.GetType() && Equals((ValueObject<T>) obj);
        }

        public override int GetHashCode() => PropertiesToCheckForEquality().Aggregate(7, (current, prop) => current * (prop.GetHashCode() + 13));
    }
}