using System;
using System.Collections.Generic;
using Inventory.Domain.Enums;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;

namespace Inventory.Domain.ValueObjects
{
    public class WarehouseLocation : ValueObject<WarehouseLocation>
    {
        public string Code { get; private set; }
        public WarehouseLocationType Type { get; private set; }

        private WarehouseLocation()
        {
        }

        public WarehouseLocation(string code, WarehouseLocationType type)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new DomainException($"{nameof(WarehouseLocation)}-{nameof(code)}", new ArgumentNullException());
            }

            this.Code = code;
            this.Type = type;
        }

        protected override IEnumerable<object> PropertiesToCheckForEquality() => new object[] {Code, Type};
    }
}