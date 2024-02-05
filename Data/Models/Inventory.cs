using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Inventory
{
    public int ProductId { get; set; }

    public string Sku { get; set; } = null!;

    public string? Unit { get; set; }

    public short? Qty { get; set; }

    public string? Manufacturer { get; set; }

    public string? ShipTime { get; set; }

    public double? ShipCost { get; set; }

    public virtual Product Product { get; set; } = null!;
}
