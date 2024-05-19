namespace StorageAccounting.Domain.Models.Common;
public class Partner
{
    public int Id { get; set; }

    public short PartnerTypeId { get; set; }

    public string Name { get; set; }

    public virtual PartnerType PartnerType { get; set; }
}
