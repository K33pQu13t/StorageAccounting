using StorageAccounting.Domain.Models.Common;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Документ отгрузки наружу
/// </summary>
public class Shipment
{
    public double Id { get; set; }

    public double DocumentId { get; set; }

    public double PartnerId { get; set; }

    public string Note { get; set; }

    public virtual Document Document { get; set; }

    public virtual Partner Partner { get; set; }
}
