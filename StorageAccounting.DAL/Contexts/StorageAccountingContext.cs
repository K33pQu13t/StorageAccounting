using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StorageAccounting.Common.Configurations;
using StorageAccounting.Domain.Configurations.Common;
using StorageAccounting.Domain.Configurations.Item;
using StorageAccounting.Domain.Configurations.StorageAccounting;
using StorageAccounting.Domain.Models.Common;
using StorageAccounting.Domain.Models.Item;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Contexts;
public class StorageAccountingContext : DbContext
{
    private readonly DbConnection _dbConnectionConfig;

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<OperationDocumentType> OperationDocumentTypes { get; set; }

    public virtual DbSet<OperationType> OperationTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Place> Place { get; set; }

    public virtual DbSet<PlaceType> PlaceTypes { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ProductTypeMark> ProductTypeMarks { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Move> Moves { get; set; }

    public virtual DbSet<MoveRegistry> MoveRegistries { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Rest> Rests { get; set; }

    public virtual DbSet<Arrival> Arrivals { get; set; }

    public virtual DbSet<ArrivalRow> ArrivalRows { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceRow> InvoiceRows { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentRow> ShipmentRows { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    public virtual DbSet<TransferRow> TransferRows { get; set; }

    public StorageAccountingContext(IOptionsMonitor<DbConnection> dbConnectionMonitor)
    {
        _dbConnectionConfig = dbConnectionMonitor.CurrentValue;
        Database.EnsureCreated();
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
