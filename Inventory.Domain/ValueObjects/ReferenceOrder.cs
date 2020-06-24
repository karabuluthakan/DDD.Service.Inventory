using System;
using System.Collections.Generic;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;

namespace Inventory.Domain.ValueObjects
{
    public class ReferenceOrder : ValueObject<ReferenceOrder>
    {
        /// <summary>
        /// Order id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Order code
        /// </summary>
        public string Code { get; private set; }

        private ReferenceOrder()
        {
        }

        public ReferenceOrder(Guid id, string code)
        {
            if (id==Guid.Empty)
            {
                throw new DomainException($"{nameof(ReferenceOrder)}-{nameof(id)}", new ArgumentNullException());
            }

            if (string.IsNullOrEmpty(code))
            {
                throw new DomainException($"{nameof(ReferenceOrder)}-{nameof(code)}", new ArgumentNullException());
            }

            this.Id = id;
            this.Code = code;
        }

        protected override IEnumerable<object> PropertiesToCheckForEquality() => new object[] {Id, Code};
    }
}