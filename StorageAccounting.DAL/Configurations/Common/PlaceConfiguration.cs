using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;

internal class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "PLACE")
            .ToTable(t =>
            {
                t.HasComment("Склад");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.PlaceTypeId).HasColumnName("Id_PlaceType");

        builder
            .HasOne(x => x.PlaceType)
            .WithMany(x => x.Places)
            .HasForeignKey(x => x.PlaceTypeId);

        builder
            .HasMany(x => x.Arrivals)
            .WithOne(x => x.Place)
            .HasForeignKey(x => x.PlaceId);

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.Place)
            .HasForeignKey(x => x.PlaceId);
    }
}
