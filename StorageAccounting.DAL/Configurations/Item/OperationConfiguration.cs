using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder
            .ToTable(schema: "ITEM", name: "OPERATION")
            .ToTable(t =>
            {
                t.HasComment("Операция");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.OperationTypeId).HasColumnName("Id_OperType");

        builder.Property(x => x.DocumentId).HasColumnName("Id_Document");

        builder.Property(x => x.StateId).HasColumnName("Id_State");

        builder
            .HasOne(x => x.OperationType)
            .WithMany(x => x.Operations)
            .HasForeignKey(x => x.OperationTypeId);

        builder
            .HasOne(x => x.Document)
            .WithMany(x => x.Operations)
            .HasForeignKey(x => x.DocumentId);

        builder
            .HasOne(x => x.State)
            .WithMany(x => x.Operations)
            .HasForeignKey(x => x.StateId);

        builder
            .HasMany(x => x.Moves)
            .WithOne(x => x.Operation)
            .HasForeignKey(x => x.OperationId);
    }
}
