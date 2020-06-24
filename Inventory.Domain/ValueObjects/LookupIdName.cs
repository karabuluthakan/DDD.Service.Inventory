using System;
using System.Collections.Generic;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;

namespace Inventory.Domain.ValueObjects
{
    public class LookupIdName : ValueObject<LookupIdName>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private LookupIdName()
        {
        }

        public LookupIdName(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new DomainException($"{nameof(LookupIdName)}-{nameof(id)}", new ArgumentNullException());
            }

            this.Id = id;
        }

        public LookupIdName(Guid id, string name) : this(id)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new DomainException($"{nameof(LookupIdName)}-{nameof(name)}", new ArgumentNullException());
            }
            
            this.Name = name;
        }

        protected override IEnumerable<object> PropertiesToCheckForEquality() => new object[] {Id};
    }
}