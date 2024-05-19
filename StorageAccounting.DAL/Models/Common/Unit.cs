namespace StorageAccounting.DAL.Models.Common;
public class Unit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public virtual ICollection<Item.Item> Items { get; set; }
}
