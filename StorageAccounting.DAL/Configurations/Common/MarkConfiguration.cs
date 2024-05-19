using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class MarkConfiguration : IEntityTypeConfiguration<Mark>
{
    public void Configure(EntityTypeBuilder<Mark> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "MARK")
            .ToTable(t =>
            {
                t.HasComment("Марка");
            });

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.ProductTypeMarks)
            .WithOne(x => x.Mark);

        builder
            .HasMany(x => x.ArrivalRows)
            .WithOne(x => x.Mark);
    }
}
