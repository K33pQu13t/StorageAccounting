namespace StorageAccounting.Domain.Models.Common;
public class ProductTypeMark
{
    public long Id { get; set; }

    public long ProductTypeId { get; set; }
    
    public long MarkId {  get; set; }

    public virtual ProductType ProductType { get; set; }

    public virtual Mark Mark { get; set; }
}
