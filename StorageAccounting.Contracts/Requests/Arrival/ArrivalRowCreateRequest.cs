namespace StorageAccounting.Contracts.Requests.Arrival;

public class ArrivalRowCreateRequest
{
    public long MarkId { get; set; }

    public long ProductTypeId { get; set; }

    public int UnitId { get; set; }

    public string Comment { get; set; } = null!;

    public decimal Amount { get; set; }
}
