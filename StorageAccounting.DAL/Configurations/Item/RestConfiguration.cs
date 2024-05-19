using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class RestConfiguration : IEntityTypeConfiguration<Rest>
{
    public void Configure(EntityTypeBuilder<Rest> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Place)
            .WithMany(x => x.Rests);

        builder
            .HasOne(x => x.Item)
            .WithMany(x => x.Rests);
    }
}
