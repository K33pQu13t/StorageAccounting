using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Models.Common;
public class Partner
{
    public long Id { get; set; }

    public short PartnerTypeId { get; set; }

    public string Name { get; set; }

    public virtual PartnerType PartnerType { get; set; }

    public virtual ICollection<Arrival> Arrivals { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; }
}
