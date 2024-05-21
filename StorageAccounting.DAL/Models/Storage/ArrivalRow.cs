using StorageAccounting.Domain.Models.Common;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Позиция документа поступления извне
/// </summary>
public class ArrivalRow
{
    public long Id { get; set; }

    public long PositionId { get; set; }

    public long MarkId { get; set; }

    public string Comment { get; set; } = null!;

    public virtual Position Position { get; set; }

    public virtual Mark Mark { get; set; }
}
