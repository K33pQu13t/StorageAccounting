using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StorageAccounting.Common.Configurations;
using StorageAccounting.Domain.Configurations.Common;
using StorageAccounting.Domain.Configurations.Item;
using StorageAccounting.Domain.Configurations.StorageAccounting;

namespace StorageAccounting.Domain.Contexts;
public class StorageAccountingContext : DbContext
{
    private readonly DbConnection _dbConnectionConfig;

    public StorageAccountingContext(IOptionsMonitor<DbConnection> dbConnectionMonitor)
    {
        _dbConnectionConfig = dbConnectionMonitor.CurrentValue;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        switch (_dbConnectionConfig.Provider)
        {
            case "SQLite":
                optionsBuilder.UseSqlite(_dbConnectionConfig.ConnectionString);
                break;
            case "PostgreSQL":
                optionsBuilder.UseNpgsql(_dbConnectionConfig.ConnectionString);
                break;
            default:
                throw new ArgumentException($"Неизвестный провайдер базы данных: {_dbConnectionConfig.Provider}");
        }

        if (!optionsBuilder.IsConfigured)
        {
            throw new ApplicationException("Не настроено подключение к базе данных");
        }
    }

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

        // Storage
        modelBuilder.ApplyConfiguration(new ArrivalConfiguration());
        modelBuilder.ApplyConfiguration(new ArrivalRowConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceRowConfiguration());
        modelBuilder.ApplyConfiguration(new ShipmentConfiguration());
        modelBuilder.ApplyConfiguration(new ShipmentRowConfiguration());
        modelBuilder.ApplyConfiguration(new TransferConfiguration());
        modelBuilder.ApplyConfiguration(new TransferRowConfiguration());
    }
}
