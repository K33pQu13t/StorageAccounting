using StorageAccounting.DAL.Models.Item;

namespace StorageAccounting.DAL.Models.Common;

public class DocumentType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Document> Documents { get; }
}
