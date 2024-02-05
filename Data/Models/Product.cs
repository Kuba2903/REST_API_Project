using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Sku { get; set; } = null!;

    public string? Name { get; set; }

    public string? Ean { get; set; }

    public string? ProducerName { get; set; }

    public string? Category { get; set; }

    public bool? IsWire { get; set; }

    public bool? IsAvailable { get; set; }

    public bool? IsVendor { get; set; }

    public string? DefaultImage { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual Price? Price { get; set; }
}
