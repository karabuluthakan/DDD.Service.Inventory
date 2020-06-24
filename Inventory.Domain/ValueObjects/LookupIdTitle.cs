using System;
using System.Collections.Generic;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;

namespace Inventory.Domain.ValueObjects
{
    public class LookupIdTitle : ValueObject<LookupIdTitle>
    {
        public Guid Id { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        private LookupIdTitle()
        {
        }

        public LookupIdTitle(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new DomainException($"{nameof(LookupIdTitle)}-{nameof(id)}", new ArgumentNullException());
            }

            this.Id = id;
        }

        public LookupIdTitle(Guid id, string key, string value) : this(id)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new DomainException($"{nameof(LookupIdTitle)}-{nameof(key)}", new ArgumentNullException());
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new DomainException($"{nameof(LookupIdTitle)}-{nameof(value)}", new ArgumentNullException());
            }

            this.Key = key;
            this.Value = value;
        }

        protected override IEnumerable<object> PropertiesToCheckForEquality() => new object[] {Id, Key, Value};
    }
}