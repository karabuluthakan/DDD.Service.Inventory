using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Inventory.Domain.Enums;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;
using Inventory.Domain.ValueObjects;

namespace Inventory.Domain.Entities
{
    public class PackageInfo : Entity<Guid>
    {
        public uint No { get; private set; }
        public WarehouseLocation Location { get; private set; }
        public LookupIdName Supplier { get; private set; }
        public LookupIdName Warehouse { get; private set; }
        public double StockValue { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime? ProductionDate { get; private set; }
        public DateTime? ExpiredDate { get; private set; }
        public PackageStatus LastStatus { get; private set; }

        private PackageInfo()
        {
        }

        public PackageInfo(Guid id) : base(id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"Id cannot be default/empty.");
            }
        }

        public PackageInfo(uint no, WarehouseLocation warehouseLocation, LookupIdName supplier, LookupIdName warehouse,
            double stockValue, string serialNumber, PackageStatus lastStatus, DateTime? productionDate,
            DateTime? expiredDate) 
        {
            if (no < 0)
            {
                throw new DomainException($"{nameof(PackageInfo)}-{nameof(no)}", new ArgumentNullException());
            }

            if (warehouseLocation == null)
            {
                throw new DomainException($"{nameof(PackageInfo)}-{nameof(warehouseLocation)}", new ArgumentNullException());
            }

            if (supplier == null)
            {
                throw new DomainException($"{nameof(PackageInfo)}-{nameof(supplier)}", new ArgumentNullException());
            }

            if (warehouse == null)
            {
                throw new DomainException($"{nameof(PackageInfo)}-{nameof(warehouse)}", new ArgumentNullException());
            }

            if (stockValue <0)
            {
                throw new DomainException($"{nameof(PackageInfo)}-{nameof(stockValue)}", new ArgumentNullException());
            } 

            if (string.IsNullOrEmpty(serialNumber))
            {
                throw new DomainException($"{nameof(PackageInfo)}-{nameof(serialNumber)}", new ArgumentNullException());
            }

            this.Location = warehouseLocation;
            this.No = no;
            this.Supplier = supplier;
            this.Warehouse = warehouse;
            this.StockValue = stockValue;
            this.SerialNumber = serialNumber;
            this.LastStatus = lastStatus;
            this.ExpiredDate = expiredDate;
            this.ProductionDate = productionDate;
        }

        internal void ChangePackageStatus(PackageStatus packageStatus)
        {
            this.LastStatus = packageStatus;
        }
    }
}