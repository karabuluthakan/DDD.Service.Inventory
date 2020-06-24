using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;

namespace Inventory.Domain.Entities
{
    public class PackageStock : Entity<Guid>
    {
        public string LotNo { get; private set; }
        public uint PackageCount { get; private set; }
        public bool IsPartialPackage { get; private set; }

        private PackageStock()
        {
        }

        public PackageStock(Guid id) : base(id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id cannot be default/empty.");
            }
        }

        public PackageStock(string lotNo, bool isPartialPackage, uint packageCount)
        {
            if (string.IsNullOrEmpty(lotNo))
            {
                throw new DomainException($"{nameof(PackageStock)}-{nameof(lotNo)}", new ArgumentNullException());
            }

            if (isPartialPackage)
            {
                if (packageCount <= 1)
                {
                    throw new InvalidDataException("Package count cannot be less than 1");
                }
            }

            this.LotNo = lotNo;
            this.PackageCount = packageCount;
            this.IsPartialPackage = isPartialPackage;
        }
    }
}