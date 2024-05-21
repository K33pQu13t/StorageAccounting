using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Документ накладной
/// </summary>
public class Invoice
{
    public long Id { get; set; }

    public long DocumentId { get; set; }

    public string Note { get; set; }

    public virtual Document Document { get; set; }
}
