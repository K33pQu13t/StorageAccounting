using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "PRODUCTTYPE")
            .ToTable(t =>
            {
                t.HasComment("Тип продукции");
            });

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.ProductTypeMarks)
            .WithOne(x => x.ProductType);

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.ProductType);
    }
}
