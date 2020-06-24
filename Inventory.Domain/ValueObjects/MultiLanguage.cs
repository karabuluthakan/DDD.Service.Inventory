using System;
using System.Collections.Generic;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;

namespace Inventory.Domain.ValueObjects
{
    public class MultiLanguage : ValueObject<MultiLanguage>
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        private MultiLanguage()
        {
        }

        public MultiLanguage(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new DomainException($"{nameof(MultiLanguage)}-{nameof(key)}", new ArgumentNullException());
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new DomainException($"{nameof(MultiLanguage)}-{nameof(value)}", new ArgumentNullException());
            }

            this.Key = key;
            this.Value = value;
        }

        protected override IEnumerable<object> PropertiesToCheckForEquality() => new object[] {Key, Value};
    }
}