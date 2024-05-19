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

    public ICollection<Move> Moves { get; set; }
}
