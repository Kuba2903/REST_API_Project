using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Price
{
    public int Id { get; set; }

    public string Sku { get; set; } = null!;

    public short? NetPrice { get; set; }

    public short? PriceAfterDiscount { get; set; }

    public byte? VatRate { get; set; }

    public short? PriceAfterDiscountLogisticUnit { get; set; }

    public virtual Product Product { get; set; } = null!;
}
