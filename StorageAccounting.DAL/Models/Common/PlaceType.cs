namespace StorageAccounting.DAL.Models.Common;

public class PlaceType
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; }
}
