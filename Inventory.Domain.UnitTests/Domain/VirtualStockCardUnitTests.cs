using System;
using Inventory.Domain.Entities;
using Inventory.Domain.Exception;
using Inventory.Domain.ValueObjects;
using Xunit;

namespace Inventory.Domain.UnitTests.Domain
{
    public class VirtualStockCardUnitTests
    {
        [Fact]
        public void Construct_ShouldThrowArgumentException_WithEmptyGuid()
        {
            var exception = Assert.Throws<ArgumentException>(() => { new VirtualStockCard(Guid.Empty); });
            Assert.Equal("Id cannot be default/empty.", exception.Message);
        }

        [Fact]
        public void Construct_ShouldThrowDomainException_WithProductOrSupplier()
        {
            var product = new LookupIdTitle(Guid.NewGuid(), "product", "Koltuk");
            var supplier = new LookupIdName(Guid.NewGuid(), "supplier");
            Assert.Throws<DomainException>(() => { new VirtualStockCard(product, null); });
            Assert.Throws<DomainException>(() => { new VirtualStockCard(null, null); });
            Assert.Throws<DomainException>(() => { new VirtualStockCard(null, supplier); });
        }

        [Fact]
        public void Construct_ShouldThrowDomainException_WithQuantity_LassThan1()
        {
            var product = new LookupIdTitle(Guid.NewGuid(), "product", "Koltuk");
            var supplier = new LookupIdName(Guid.NewGuid(), "supplier");
            var exception = Assert.Throws<DomainException>(() => { new VirtualStockCard(product, supplier, 0); });
            Assert.Equal("Quantity cannot less than 1",exception.Message);
        }
    }
}