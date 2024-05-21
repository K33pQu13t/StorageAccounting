using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class MoveRegistryConfiguration : IEntityTypeConfiguration<MoveRegistry>
{
    public void Configure(EntityTypeBuilder<MoveRegistry> builder)
    {
        builder
            .ToTable(schema: "ITEM", name: "MOVE_REGISTRY")
            .ToTable(t =>
            {
                t.HasComment("Реестр учётных единиц");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();
    }
}
