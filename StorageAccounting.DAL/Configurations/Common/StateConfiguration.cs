using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;
internal class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Operations)
            .WithOne(x => x.State);
    }
}
