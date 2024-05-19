using StorageAccounting.Domain.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAccounting.Domain.Models.Storage;
public class InvoiceRow
{
    public double Id { get; set; }

    public double PositionId { get; set; }

    public decimal Count { get; set; }

    public decimal Price { get; set; }

    public decimal Netto { get; set; }

    public decimal Brutto { get; set; }

    public Position Position { get; set; }
}
