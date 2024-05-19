using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Common;
public class OperationType
{
    public short Id { get; set; }

    public short Name { get; set; }

    public virtual ICollection<Operation> Operations { get; set; }
}
