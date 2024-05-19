using StorageAccounting.DAL.Models.Item;

namespace StorageAccounting.DAL.Models.Common;

public class Place
{
    public int Id { get; set; }

    public short PlaceTypeId { get; set; }

    public string Name { get; set; }

    public virtual PlaceType PlaceType { get; set; }

    public virtual ICollection<Item.Item> Items { get; set; }

    public virtual ICollection<Rest> Rests { get; set; }
}
