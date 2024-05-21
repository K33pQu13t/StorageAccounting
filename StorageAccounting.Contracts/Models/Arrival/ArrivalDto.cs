namespace StorageAccounting.Contracts.Models.Arrival;
public class ArrivalDto
{
    public long Id { get; set; }

    public long DocumentId { get; set; }

    public long PartnerId { get; set; }

    public string PartnerName { get; set; }

    public int PlaceId { get; set; }

    public string PlaceName { get; set; }

    public DateTime DateArrival { get; set; }

    public bool IsDeffect { get; set; }

    public List<ArrivalRowDto> Rows { get; set; }
}
