using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Configurations.StorageAccounting;
internal class ArrivalConfiguration : IEntityTypeConfiguration<Arrival>
{
    public void Configure(EntityTypeBuilder<Arrival> builder)
    {
        builder
            .ToTable(schema: "STORAGE", name: "ARRIVAL")
            .ToTable(t =>
            {
                t.HasComment("Документ поступления извне");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.DocumentId).HasColumnName("Id_Document");

        builder.Property(x => x.PartnerId).HasColumnName("Id_Partner");

        builder.Property(x => x.PlaceId).HasColumnName("Id_Place");

        builder
            .HasOne(x => x.Document)
            .WithMany(x => x.Arrivals)
            .HasForeignKey(x => x.DocumentId);

        builder
            .HasOne(x => x.Partner)
            .WithMany(x => x.Arrivals)
            .HasForeignKey(x => x.PartnerId);

        builder
            .HasOne(x => x.Place)
            .WithMany(x => x.Arrivals)
            .HasForeignKey(x => x.PlaceId);
    }
}
