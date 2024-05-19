using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class MoveRegistryConfiguration : IEntityTypeConfiguration<MoveRegistry>
{
    public void Configure(EntityTypeBuilder<MoveRegistry> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
