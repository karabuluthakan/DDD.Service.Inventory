using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configurations
{
    public class PackageInfoConfiguration : IEntityTypeConfiguration<PackageInfo>
    {
        public void Configure(EntityTypeBuilder<PackageInfo> builder)
        {
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Location).IsRequired();
            builder.Property(x => x.Supplier).IsRequired();
            builder.Property(x => x.Warehouse).IsRequired();
            builder.Property(x => x.StockValue).IsRequired();
            builder.Property(x => x.SerialNumber).IsRequired();
            builder.Property(x => x.LastStatus).IsRequired();
        }
    }
}