namespace StorageAccounting.Domain.Models.Common;
public class ProductTypeMark
{
    public double Id { get; set; }

    public int ProductTypeId { get; set; }
    
    public int MarkId {  get; set; }

    public virtual ProductType ProductType { get; set; }

    public virtual Mark Mark { get; set; }
}
