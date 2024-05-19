using StorageAccounting.DAL.Models.Item;

namespace StorageAccounting.DAL.Models.Common;
public class OperationType
{
    public short Id { get; set; }

    public short Name { get; set; }

    public virtual ICollection<Operation> Operations { get; set; }
}
