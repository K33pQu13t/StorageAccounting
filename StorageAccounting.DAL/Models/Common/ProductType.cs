namespace StorageAccounting.Domain.Models.Common;

public class ProductType
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string NameShort { get; set; }

    public virtual ICollection<ProductTypeMark> ProductTypeMarks { get; set; }

    public virtual ICollection<Item.Item> Items { get; set; }
}
