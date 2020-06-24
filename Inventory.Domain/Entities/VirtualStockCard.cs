using System;
using System.IO; 
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;
using Inventory.Domain.ValueObjects;

namespace Inventory.Domain.Entities
{
    public class VirtualStockCard : Entity<Guid>
    {
        public LookupIdTitle Product { get; private set; }
        public LookupIdName Supplier { get; private set; }
        public double? Threshold { get; private set; }
        public double? Quantity { get; private set; }

        public VirtualStockCard(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"Id cannot be default/empty.");
            }
        }

        public VirtualStockCard(LookupIdTitle product, LookupIdName supplier)  
        {
            if (product == null)
            {
                throw new DomainException($"{nameof(PackageStock)}-{nameof(product)}", new ArgumentNullException());
            }

            if (supplier == null)
            {
                throw new DomainException($"{nameof(PackageStock)}-{nameof(supplier)}", new ArgumentNullException());
            }

            this.Product = product;
            this.Supplier = supplier;
        }

        public VirtualStockCard(LookupIdTitle product, LookupIdName supplier, double? quantity) : this(product, supplier)
        {
            if (quantity < 1)
            {
                throw new DomainException("Quantity cannot less than 1", new InvalidDataException());
            }

            this.Quantity = quantity;
        }

        public VirtualStockCard(LookupIdTitle product, LookupIdName supplier, double? quantity, double? threshold) : this(product, supplier, quantity)
        {
            this.Threshold = threshold;
        } 
    }
}