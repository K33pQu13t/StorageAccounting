using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Документ внутреннего перемещения продукции между складами
/// </summary>
public class Transfer
{
    public long Id { get; set; }

    public long DocumentId {  get; set; }

    public int PlaceFrom { get; set; }

    public int PlaceTo { get; set; }

    public string Note { get; set; }

    public virtual Document Document { get; set; }
}
