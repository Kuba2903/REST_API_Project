using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Price
    {
        public int Id { get; set; }

        [MaxLength(16)]
        public string SKU { get; set; }

        public double net_price { get; set; }

        public double net_price_after_discount { get; set; }

        public short vat_rate { get; set; }

        public double net_price_after_discount_for_logistic_unit { get; set; }

    }
}
