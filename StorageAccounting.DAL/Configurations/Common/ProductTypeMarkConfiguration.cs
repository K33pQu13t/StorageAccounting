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
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.ProductTypeId).HasColumnName("Id_ProductType");

        builder.Property(x => x.MarkId).HasColumnName("Id_Mark");

        builder
            .HasOne(x => x.ProductType)
            .WithMany(x => x.ProductTypeMarks)
            .HasForeignKey(x => x.ProductTypeId);

        builder
            .HasOne(x => x.Mark)
            .WithMany(x => x.ProductTypeMarks)
            .HasForeignKey(x => x.MarkId);
    }
}
