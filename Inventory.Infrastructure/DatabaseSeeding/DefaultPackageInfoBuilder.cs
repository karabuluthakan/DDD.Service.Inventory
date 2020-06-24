/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Domain.Entities;
using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects;
using Inventory.Infrastructure.EntityFramework;

namespace Inventory.Infrastructure.DatabaseSeeding
{
    internal class DefaultPackageInfoBuilder
    {
        private readonly InventoryDbContext _dbContext;

        public DefaultPackageInfoBuilder(InventoryDbContext dbContext) => _dbContext = dbContext;

        public void Create()
        {
            if (_dbContext.PackageInfos.Any())
            {
                return;
            }

            var random = new Random();
            var number = random.Next(2, 10);
            var isPartialPackage = random.Next(2, 10) % 2 == 0;
            var maxValue = 1;
            if (isPartialPackage)
            {
                maxValue = number;
            }

            var packageStock = new PackageStock(Guid.NewGuid(), Guid.NewGuid().ToString(), isPartialPackage, maxValue);
            var warehouseLocationTypeRandom = random.Next(1, 3);
            var warehouseLocationType = warehouseLocationTypeRandom switch
            {
                1 => WarehouseLocationType.Shelf, 2 => WarehouseLocationType.Transportation, _ => WarehouseLocationType.CollectionArea
            };
            var warehouseLocation = new WarehouseLocation(Guid.NewGuid().ToString(), warehouseLocationType);
            var supplier = new LookupIdName(Guid.NewGuid(), "Supplier");
            var warehouse = new LookupIdName(Guid.NewGuid(), "Warehouse");
            var packageStatusRandom = random.Next(1, 8);
            var packageStatus = packageStatusRandom switch
            {
                1 => PackageStatus.Consign, 2 => PackageStatus.Cross, 3 => PackageStatus.Damaged, 4 => PackageStatus.Issue, 5 => PackageStatus.None,
                6 => PackageStatus.Out, 7 => PackageStatus.Reserved, _ => PackageStatus.Salable
            };

            var packageMovements = new List<PackageMovement>();
            var packageMovementsRandom = random.Next(1, 8);
            var movementTypeRandom = random.Next(1, 3);
            var movementType = movementTypeRandom switch
            {
                1 => MovementType.Receipt, 2 => MovementType.InWarehouseTransfer, _ => MovementType.Exit
            };
            for (var i = 0; i < packageMovementsRandom; i++)
            {
                packageMovements.Add(new PackageMovement(Guid.NewGuid(), new ReferenceOrder(Guid.NewGuid(), Guid.NewGuid().ToString()), movementType,
                    DateTime.Now, new UserSummary(Guid.NewGuid(), "Hakan Karabulut", "hakankarabulut@gmail.com"), warehouseLocation, packageStatus,
                    Guid.NewGuid().ToString(), "Description"));
            }

            var packageInfoRandom = random.Next(1, 10);
            var packageInfos = new List<PackageInfo>();
            for (var i = 0; i < packageInfoRandom; i++)
            {
                packageInfos.Add(new PackageInfo(i + 1, packageStock, warehouseLocation, supplier, warehouse, maxValue, Guid.NewGuid().ToString(),
                    packageStatus, packageMovements, DateTime.Now, DateTime.Now));
            }

            _dbContext.PackageInfos.AddRange(packageInfos);
            _dbContext.SaveChanges();
        }
    }
}*/