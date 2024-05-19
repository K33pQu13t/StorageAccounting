using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;
internal class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.ProductTypeMarks)
            .WithOne(x => x.ProductType);

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.ProductType);
    }
}
