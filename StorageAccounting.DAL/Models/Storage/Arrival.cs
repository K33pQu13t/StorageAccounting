using StorageAccounting.Domain.Models.Common;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Документ поступления извне
/// </summary>
public class Arrival
{
    public long Id { get; set; }
    
    public long DocumentId { get; set; }

    public long PartnerId { get; set; }

    public int PlaceId { get; set; }

    public DateTime DateArrival { get; set; }

    public bool IsDeffect { get; set; }

    public virtual Document Document { get; set; }

    public virtual Partner Partner { get; set; }

    public virtual Place Place { get; set; }
}
