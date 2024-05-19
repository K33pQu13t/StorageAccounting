using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;
internal class PlaceTypeConfiguration : IEntityTypeConfiguration<PlaceType>
{
    public void Configure(EntityTypeBuilder<PlaceType> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Places)
            .WithOne(x => x.PlaceType);
    }
}
