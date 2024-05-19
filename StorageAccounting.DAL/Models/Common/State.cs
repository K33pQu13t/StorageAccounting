using StorageAccounting.DAL.Models.Item;

namespace StorageAccounting.DAL.Models.Common;

public class State
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; set; }
}
