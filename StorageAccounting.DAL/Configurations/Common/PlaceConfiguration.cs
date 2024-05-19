using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;

internal class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.PlaceType)
            .WithMany(x => x.Places);
    }
}
