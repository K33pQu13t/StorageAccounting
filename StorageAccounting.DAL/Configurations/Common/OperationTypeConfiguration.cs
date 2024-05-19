using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;
internal class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
{
    public void Configure(EntityTypeBuilder<OperationType> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Operations)
            .WithOne(x => x.OperationType);
    }
}
