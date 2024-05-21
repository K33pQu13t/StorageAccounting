using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Models.Common;
public class Mark
{
    public long Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<ProductTypeMark> ProductTypeMarks { get; set; }

    public virtual ICollection<ArrivalRow> ArrivalRows { get; set; }
}
