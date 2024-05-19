using Microsoft.EntityFrameworkCore;
using StorageAccounting.Domain.Configurations.Common;
using StorageAccounting.Domain.Configurations.Item;

namespace StorageAccounting.Domain.Contexts;
public class StorageAccountingContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Common
        modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MarkConfiguration());
        modelBuilder.ApplyConfiguration(new OperationTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PartnerConfiguration());
        modelBuilder.ApplyConfiguration(new PartnerTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PlaceConfiguration());
        modelBuilder.ApplyConfiguration(new PlaceTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductTypeMarkConfiguration());
        modelBuilder.ApplyConfiguration(new StateConfiguration());
        modelBuilder.ApplyConfiguration(new UnitConfiguration());

        // Item
        modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new MoveConfiguration());
        modelBuilder.ApplyConfiguration(new MoveRegistryConfiguration());
        modelBuilder.ApplyConfiguration(new OperationConfiguration());
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        modelBuilder.ApplyConfiguration(new RestConfiguration());
    }
}
