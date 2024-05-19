using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Common;

public class State
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; set; }
}
