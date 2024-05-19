using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Item;

namespace StorageAccounting.DAL.Configurations.Item;
internal class MoveRegistryConfiguration : IEntityTypeConfiguration<MoveRegistry>
{
    public void Configure(EntityTypeBuilder<MoveRegistry> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
