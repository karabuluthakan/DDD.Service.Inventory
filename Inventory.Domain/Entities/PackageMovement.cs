using System;
using Inventory.Domain.Enums;
using Inventory.Domain.SharedKernel;
using Inventory.Domain.ValueObjects;

namespace Inventory.Domain.Entities
{
    public class PackageMovement : Entity<Guid>
    {
        public ReferenceOrder ReferenceOrder { get; private set; }
        public MovementType MovementType { get; private set; }
        public DateTime Time { get; private set; }
        public UserSummary ActionBy { get; private set; }
        public WarehouseLocation Target { get; private set; }
        public string Description { get; set; }
        public PackageStatus PackageStatus { get; private set; }
        public string TransportationId { get; private set; }

        private PackageMovement()
        {
        }

        public PackageMovement(Guid id) : base(id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"Id cannot be default/empty.");
            }
        }

        internal void ChangeMovementType(MovementType movementType)
        {
            this.MovementType = movementType;
        }

        internal void ChangePackageStatus(PackageStatus packageStatus)
        {
            this.PackageStatus = packageStatus;
        }
    }
}