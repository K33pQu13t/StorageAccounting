namespace StorageAccounting.Contracts.Models.Arrival;
public class ArrivalDto
{
    public double Id { get; set; }

    public double DocumentId { get; set; }

    public int PartnerId { get; set; }

    public string PartnerName { get; set; }

    public int PlaceId { get; set; }

    public string PlaceName { get; set; }

    public DateTime DateArrival { get; set; }

    public bool IsDeffect { get; set; }
}
