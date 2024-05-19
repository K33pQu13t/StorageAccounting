using StorageAccounting.Domain.Models.Common;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Позиция документа поступления извне
/// </summary>
public class ArrivalRow
{
    public double Id { get; set; }

    public double PositionId { get; set; }

    public double MarkId { get; set; }

    public string Comment { get; set; }

    public virtual Position Position { get; set; }

    public virtual Mark Mark { get; set; }
}
