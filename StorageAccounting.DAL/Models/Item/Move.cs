namespace StorageAccounting.DAL.Models.Item;

public class Move
{
    public long Id { get; set; }

    public long PositionId { get; set; }

    public DateTime DateCreate { get; set; }

    public short Direction { get; set; }

    public int Amount { get; set; }

    public int AmountPlan { get; set; }

    public long OperationId { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual Operation Operation { get; set; } = null!;
}
