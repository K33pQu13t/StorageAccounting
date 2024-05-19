using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Common;

public class OperationDocumentType
{
    public double Id { get; set; }

    public double OperationId { get; set; }

    public int DocumentTypeId { get; set; }

    public virtual Operation Operation { get; set; }

    public virtual DocumentType DocumentType { get; set; }
}
