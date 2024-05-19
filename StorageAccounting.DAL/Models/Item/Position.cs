using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Models.Item;

public class Position
{
    public double Id { get; set; }

    public double DocumentId { get; set; }

    public double ItemId { get; set; }

    public DateTime DateCreate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    public ICollection<Move> Moves { get; set; }

    public ICollection<InvoiceRow> InvoiceRows { get; set; }

    public ICollection<ArrivalRow> ArrivalRows { get; set; }

    public ICollection<ShipmentRow> ShipmentRows { get; set; }

    public ICollection<TransferRow> TransferRows { get; set; }
}
