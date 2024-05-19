namespace StorageAccounting.DAL.Models.Common;
public class Mark
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<ProductTypeMark> ProductTypeMarks { get; set; }
}
