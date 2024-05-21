namespace StorageAccounting.Domain.Models.Item;

public class Move
{
    public long Id { get; set; }

    public long PositionId { get; set; }

    public long OperationId { get; set; }

    public DateTime DateCreate { get; set; }

    public short Direction { get; set; }

    public decimal Amount { get; set; }

    public decimal AmountPlan { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual Operation Operation { get; set; } = null!;
}
