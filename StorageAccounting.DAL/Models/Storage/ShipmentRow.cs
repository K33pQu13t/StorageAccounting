using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Позиция документа отгрузки вне
/// </summary>
public class ShipmentRow
{
    public long Id { get; set; }

    public long PositionId { get; set; }

    public string Name { get; set; }

    public Position Position { get; set; }
}
