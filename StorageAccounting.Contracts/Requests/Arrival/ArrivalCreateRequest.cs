namespace StorageAccounting.Contracts.Requests.Arrival;
public class ArrivalCreateRequest
{
    public long PartnerId { get; set; }

    public int PlaceId { get; set; }

    public DateTime DateArrival { get; set; }

    public bool IsDeffect { get; set; }

    public List<ArrivalRowCreateRequest> Rows { get; set; }
}
