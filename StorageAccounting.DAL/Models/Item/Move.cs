namespace StorageAccounting.Domain.Models.Item;

public class Move
{
    public double Id { get; set; }

    public double PositionId { get; set; }

    public DateTime DateCreate { get; set; }

    public short Direction { get; set; }

    public decimal Amount { get; set; }

    public decimal AmountPlan { get; set; }

    public double OperationId { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual Operation Operation { get; set; } = null!;
}
