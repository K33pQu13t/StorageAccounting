using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Models.Common;

public class DocumentType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Document> Documents { get; }
}
