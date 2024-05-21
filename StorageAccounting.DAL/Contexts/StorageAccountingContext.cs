using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StorageAccounting.Common.Configurations;
using StorageAccounting.Contracts.Enums.Common;
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

    public virtual DbSet<Place> Places { get; set; }

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
        modelBuilder.ApplyConfiguration(new OperationDocumentTypeConfiguration());
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

        Seeding(modelBuilder);
    }

    private static void Seeding(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentType>().HasData(
            new DocumentType() { Id = (int)DocTypes.Arrival, Name = "Документ Поступления" });

        modelBuilder.Entity<PlaceType>().HasData(
            new PlaceType() { Id = (int)Common.Enums.Common.PlaceTypes.RawMaterials, Name = "Склад сырья" },
            new PlaceType() { Id = (int)Common.Enums.Common.PlaceTypes.ReadyProducts, Name = "Склад готовой продукции" });

        modelBuilder.Entity<Place>().HasData(
            new Place() { Id = 1, Name = "Склад сырья №1", PlaceTypeId = (int)Common.Enums.Common.PlaceTypes.RawMaterials },
            new Place() { Id = 2, Name = "Склад сырья №2", PlaceTypeId = (int)Common.Enums.Common.PlaceTypes.RawMaterials },
            new Place() { Id = 3, Name = "СГП №1", PlaceTypeId = (int)Common.Enums.Common.PlaceTypes.ReadyProducts },
            new Place() { Id = 4, Name = "СГП №2", PlaceTypeId = (int)Common.Enums.Common.PlaceTypes.ReadyProducts });

        modelBuilder.Entity<PartnerType>().HasData(
            new PartnerType() { Id = (int)Common.Enums.Common.PartnerTypes.MaterialManufacturer, Name = "Изготовитель сырья" },
            new PartnerType() { Id = (int)Common.Enums.Common.PartnerTypes.Reciever, Name = "Потребитель" });

        modelBuilder.Entity<Partner>().HasData(
            new Partner() { Id = 1, Name = "ПАО РУСАЛ", PartnerTypeId = (int)Common.Enums.Common.PartnerTypes.MaterialManufacturer },
            new Partner() { Id = 2, Name = "ОАО КРАСЦВЕТМЕТ", PartnerTypeId = (int)Common.Enums.Common.PartnerTypes.MaterialManufacturer },
            new Partner() { Id = 3, Name = "ООО СИБТЯЖМАШ", PartnerTypeId = (int)Common.Enums.Common.PartnerTypes.Reciever },
            new Partner() { Id = 4, Name = "АО АВТОВАЗ", PartnerTypeId = (int)Common.Enums.Common.PartnerTypes.Reciever });

        modelBuilder.Entity<ProductType>().HasData(
            new ProductType() { Id = (int)Common.Enums.Common.ProductTypes.Peat, Name = "Торф", NameShort = "Торф" },
            new ProductType() { Id = (int)Common.Enums.Common.ProductTypes.Carbon, Name = "Уголь", NameShort = "Уголь" },
            new ProductType() { Id = (int)Common.Enums.Common.ProductTypes.Alumina, Name = "Глинозём", NameShort = "Глинозём" });

        modelBuilder.Entity<Mark>().HasData(
            new Mark() { Id = (int)Common.Enums.Common.Marks.T10, Name = "T10" },
            new Mark() { Id = (int)Common.Enums.Common.Marks.T20, Name = "T20" },
            new Mark() { Id = (int)Common.Enums.Common.Marks.Carbon3000, Name = "Carbon3000" },
            new Mark() { Id = (int)Common.Enums.Common.Marks.Al90, Name = "AL-90" },
            new Mark() { Id = (int)Common.Enums.Common.Marks.Al92, Name = "AL-92" });

        modelBuilder.Entity<ProductTypeMark>().HasData(
            new ProductTypeMark() { Id = 1, ProductTypeId = (int)Common.Enums.Common.ProductTypes.Peat, MarkId = (int)Common.Enums.Common.Marks.T10 },
            new ProductTypeMark() { Id = 2, ProductTypeId = (int)Common.Enums.Common.ProductTypes.Peat, MarkId = (int)Common.Enums.Common.Marks.T20 },
            new ProductTypeMark() { Id = 3, ProductTypeId = (int)Common.Enums.Common.ProductTypes.Carbon, MarkId = (int)Common.Enums.Common.Marks.Carbon3000 },
            new ProductTypeMark() { Id = 4, ProductTypeId = (int)Common.Enums.Common.ProductTypes.Alumina, MarkId = (int)Common.Enums.Common.Marks.Al90 },
            new ProductTypeMark() { Id = 5, ProductTypeId = (int)Common.Enums.Common.ProductTypes.Alumina, MarkId = (int)Common.Enums.Common.Marks.Al92 });

        modelBuilder.Entity<Unit>().HasData(
            new Unit() { Id = (int)Common.Enums.Common.Units.Piece, Name = "штук", ShortName = "шт." },
            new Unit() { Id = (int)Common.Enums.Common.Units.Kg, Name = "килограмм", ShortName = "кг." });

        modelBuilder.Entity<State>().HasData(
            new State() { Id = (int)Common.Enums.Common.States.New, Name = "Новый" },
            new State() { Id = (int)Common.Enums.Common.States.Accepted, Name = "Подтверждён" },
            new State() { Id = (int)Common.Enums.Common.States.Rejected, Name = "Отклонён" });

        modelBuilder.Entity<OperationType>().HasData(
            new OperationType() { Id = (int)Common.Enums.Common.OperationTypes.ArrivalCreate, Name = "Создание документа Поступления"},
            new OperationType() { Id = (int)Common.Enums.Common.OperationTypes.ArrivalUpdate, Name = "Обновление документа Поступления"},
            new OperationType() { Id = (int)Common.Enums.Common.OperationTypes.ArrivalAccept, Name = "Подтверждение документа Поступления"},
            new OperationType() { Id = (int)Common.Enums.Common.OperationTypes.ArrivalReject, Name = "Отклонение документа Поступления"});

        modelBuilder.Entity<OperationDocumentType>().HasData(
            new OperationDocumentType() { Id = 1, DocumentTypeId = (int)DocTypes.Arrival, OperationTypeId = (int)Common.Enums.Common.OperationTypes.ArrivalCreate },
            new OperationDocumentType() { Id = 2, DocumentTypeId = (int)DocTypes.Arrival, OperationTypeId = (int)Common.Enums.Common.OperationTypes.ArrivalUpdate },
            new OperationDocumentType() { Id = 3, DocumentTypeId = (int)DocTypes.Arrival, OperationTypeId = (int)Common.Enums.Common.OperationTypes.ArrivalAccept },
            new OperationDocumentType() { Id = 4, DocumentTypeId = (int)DocTypes.Arrival, OperationTypeId = (int)Common.Enums.Common.OperationTypes.ArrivalReject });

        modelBuilder.Entity<MoveRegistry>().HasData(new MoveRegistry() { Id = 1, DateFact = DateTime.Now });
    }
}
