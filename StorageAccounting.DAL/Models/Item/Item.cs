﻿using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Models.Item;

public class Item
{
    public long Id { get; set; }

    public int ProductTypeId { get; set; }

    public int UnitId { get; set; }

    public int PlaceId { get; set; }

    public int Amount { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;

    public virtual Place Place { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; set; }

    public virtual ICollection<Rest> Rests { get; set; }
}