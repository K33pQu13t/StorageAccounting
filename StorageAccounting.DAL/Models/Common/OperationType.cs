using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Common;
public class OperationType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<OperationDocumentType> OperationDocumentTypes { get; set; }

    public virtual ICollection<Operation> Operations { get; set; }
}
