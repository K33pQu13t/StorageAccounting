using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Models.Item;

public class Rest
{
    public long Id { get; set; }

    public int PlaceId { get; set; }

    public int ItemId { get; set; }

    public DateTime DateCreate { get; set; }

    public int Amount { get; set; }

    public int AmountPlan { get; set; }

    public Place Place { get; set; } = null!;

    public Item Item { get; set; } = null!;
}
