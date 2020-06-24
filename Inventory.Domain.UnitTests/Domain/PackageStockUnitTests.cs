using System;
using System.IO;
using Inventory.Domain.Entities;
using Inventory.Domain.Exception;
using Xunit;

// ReSharper disable All

namespace Inventory.Domain.UnitTests
{
    public class PackageStockUnitTests
    {
        [Fact]
        public void Construct_ShouldThrowArgumentException_WithEmptyGuid()
        {
            var exception = Assert.Throws<ArgumentException>(() => { new PackageStock(Guid.Empty); });
            Assert.Equal("Id cannot be default/empty.", exception.Message);
        }

        [Fact]
        public void Construct_ShouldThrowDomainException_WithEmptyLotNo()
        {
            var exception = Assert.Throws<DomainException>(() => { new PackageStock("", false, 1); });
            Assert.Equal($"{nameof(PackageStock)}-lotNo", exception.Message);
        }

        [Fact]
        public void Construct_ShouldThrowDomainException_WithIsPartialTrue_PackageCount()
        {
            var exception = Assert.Throws<InvalidDataException>(() => { new PackageStock(Guid.NewGuid().ToString(), true, 1); });
            Assert.Equal("Package count cannot be less than 1", exception.Message);
        }
    }
}