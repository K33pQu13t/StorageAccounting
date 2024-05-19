using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.OperationType)
            .WithMany(x => x.Operations);

        builder
            .HasOne(x => x.Document)
            .WithMany(x => x.Operations);

        builder
            .HasOne(x => x.State)
            .WithMany(x => x.Operations);

        builder
            .HasMany(x => x.Moves)
            .WithOne(x => x.Operation);
    }
}
