using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [PrimaryKey(nameof(ProductId), nameof(SKU))]
    public class Price
    {

        [MaxLength(16)]
        public string SKU { get; set; }

        public double net_price { get; set; }

        public double net_price_after_discount { get; set; }

        public short vat_rate { get; set; }

        public double net_price_after_discount_for_logistic_unit { get; set; }

        //Navigation property needed to create a one to one relation with Product table
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
