﻿using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Models.Item;

public class Document
{
    public long Id { get; set; }

    public int DocumentTypeId { get; set; }

    /// <summary>
    /// Дата, на которую назначен документ
    /// </summary>
    public DateTime DateFact { get; set; }

    /// <summary>
    /// Дата создания документа
    /// </summary>
    public DateTime DateCreate { get; set; }

    public bool? IsDeleted { get; set; }

    public bool IsSigned { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; set; }

    public virtual ICollection<Operation> Operations { get; set; }
}
