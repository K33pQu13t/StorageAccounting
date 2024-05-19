using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Позиция документа внутреннего перемещения продукции между складами
/// </summary>
public class TransferRow
{
    public double Id { get; set; }

    /// <summary>
    /// Количество, которое перемещают
    /// </summary>
    public decimal Amount { get; set; }

    public double PositionId { get; set; }

    public virtual Position Position { get; set; }
}
