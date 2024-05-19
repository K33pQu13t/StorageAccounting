using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;
internal class MarkConfiguration : IEntityTypeConfiguration<Mark>
{
    public void Configure(EntityTypeBuilder<Mark> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.ProductTypeMarks)
            .WithOne(x => x.Mark);
    }
}
