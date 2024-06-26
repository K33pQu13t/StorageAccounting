﻿using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Models.Item;

public class Operation
{
    public long Id { get; set; }

    public int OperationTypeId { get; set; }

    public long DocumentId { get; set; }

    public int StateId { get; set; }

    public DateTime DateCreate { get; set; }

    public virtual OperationType OperationType { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;

    public virtual State State { get; set; } = null!;

    public virtual ICollection<Move> Moves { get; set; }
}
