namespace StorageAccounting.DAL.Models.Common;
public class PartnerType
{
    public short Id { get; set; }

    public string Name { get; set; }

    public ICollection<Partner> Partners { get; set; }
}
