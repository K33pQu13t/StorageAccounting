using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Models.Item;

public class Rest
{
    public long Id { get; set; }

    public int PlaceId { get; set; }

    public long ItemId { get; set; }

    public DateTime DateCreate { get; set; }

    public decimal Amount { get; set; }

    public decimal AmountPlan { get; set; }

    public Place Place { get; set; } = null!;

    public Item Item { get; set; } = null!;
}
