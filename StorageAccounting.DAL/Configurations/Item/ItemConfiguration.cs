using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StorageAccounting.Domain.Configurations.Item;

internal class ItemConfiguration : IEntityTypeConfiguration<Models.Item.Item>
{
    public void Configure(EntityTypeBuilder<Models.Item.Item> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.ProductType)
            .WithMany(x => x.Items);

        builder
            .HasOne(x => x.Unit)
            .WithMany(x => x.Items);

        builder
            .HasOne(x => x.Place)
            .WithMany(x => x.Items);
    }
}
