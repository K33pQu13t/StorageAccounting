﻿using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Models.Item;

public class Operation
{
    public double Id { get; set; }

    public short OperationTypeId { get; set; }

    public double DocumentId { get; set; }

    public int StateId { get; set; }

    public DateTime DateCreate { get; set; }

    public virtual OperationType OperationType { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;

    public virtual State State { get; set; } = null!;

    public virtual ICollection<Move> Moves { get; set; }

    public virtual ICollection<OperationDocumentType> OperationDocumentTypes { get; set; }
}
