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
        builder.Property(x => x.Id)
            .HasIdentityOptions(startValue: 100)
            .UseIdentityAlwaysColumn();

        builder
            .HasMany(x => x.ProductTypeMarks)
            .WithOne(x => x.ProductType)
            .HasForeignKey(x => x.ProductTypeId);

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.ProductType)
            .HasForeignKey(x => x.ProductTypeId);
    }
}
