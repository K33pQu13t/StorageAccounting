using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class ProductTypeMarkConfiguration : IEntityTypeConfiguration<ProductTypeMark>
{
    public void Configure(EntityTypeBuilder<ProductTypeMark> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "PRODUCTTYPE_MARK")
            .ToTable(t =>
            {
                t.HasComment("Связь типа продукции с маркой");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductTypeId).HasColumnName("ID_PRODUCTTYPE");

        builder.Property(x => x.MarkId).HasColumnName("ID_MARK");

        builder
            .HasOne(x => x.ProductType)
            .WithMany(x => x.ProductTypeMarks);

        builder
            .HasOne(x => x.Mark)
            .WithMany(x => x.ProductTypeMarks);
    }
}
