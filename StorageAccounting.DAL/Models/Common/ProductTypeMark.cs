﻿namespace StorageAccounting.DAL.Models.Common;
public class ProductTypeMark
{
    public long Id { get; set; }

    public int ProductTypeId { get; set; }
    
    public int MarkId {  get; set; }

    public virtual ProductType ProductType { get; set; }

    public virtual Mark Mark { get; set; }
}