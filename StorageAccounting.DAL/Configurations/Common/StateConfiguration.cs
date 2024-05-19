using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "STATE")
            .ToTable(t =>
            {
                t.HasComment("Состояние");
            });

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Operations)
            .WithOne(x => x.State);
    }
}
