using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Common;

public class OperationDocumentType
{
    public long Id { get; set; }

    public int OperationTypeId { get; set; }

    public int DocumentTypeId { get; set; }

    public virtual OperationType OperationType { get; set; }

    public virtual DocumentType DocumentType { get; set; }
}
