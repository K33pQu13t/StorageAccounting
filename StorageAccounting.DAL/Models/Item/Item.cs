using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Models.Item;

public class Item
{
    public double Id { get; set; }

    public int ProductTypeId { get; set; }

    public int UnitId { get; set; }

    public int PlaceId { get; set; }

    public decimal Amount { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;

    public virtual Place Place { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; set; }

    public virtual ICollection<Rest> Rests { get; set; }
}
