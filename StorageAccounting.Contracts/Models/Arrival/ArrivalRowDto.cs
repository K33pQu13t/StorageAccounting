namespace StorageAccounting.Contracts.Models.Arrival;
public class ArrivalRowDto
{
    public long Id { get; set; }

    public long MarkId { get; set; }

    public string MarkName { get; set; } = null!;

    public long ProductTypeId { get; set; }

    public string ProductTypeName { get; set; } = null!;

    public long ProductTypeMarkId { get; set; }

    public string Comment { get; set; } = null!;
}
