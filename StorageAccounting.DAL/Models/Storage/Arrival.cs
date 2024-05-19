using StorageAccounting.Domain.Models.Common;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Документ поступления извне
/// </summary>
public class Arrival
{
    public double Id { get; set; }
    
    public double DocumentId { get; set; }

    public int PartnerId { get; set; }

    public int PlaceId { get; set; }

    public DateTime DateArrival { get; set; }

    public bool IsDeffect { get; set; }

    public virtual Document Document { get; set; }

    public virtual Partner Partner { get; set; }

    public virtual Place Place { get; set; }
}
