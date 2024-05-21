using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Models.Item;

public class Position
{
    public long Id { get; set; }

    public long DocumentId { get; set; }

    public long ItemId { get; set; }

    public DateTime DateCreate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    public virtual ICollection<Move> Moves { get; set; }

    public virtual ICollection<InvoiceRow> InvoiceRows { get; set; }

    public virtual ICollection<ArrivalRow> ArrivalRows { get; set; }

    public virtual ICollection<ShipmentRow> ShipmentRows { get; set; }

    public virtual ICollection<TransferRow> TransferRows { get; set; }
}
