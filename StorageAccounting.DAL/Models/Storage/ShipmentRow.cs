using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Storage;

/// <summary>
/// Позиция документа отгрузки вне
/// </summary>
public class ShipmentRow
{
    public double Id { get; set; }

    public double PositionId { get; set; }

    public string Name { get; set; }

    public Position Position { get; set; }
}
