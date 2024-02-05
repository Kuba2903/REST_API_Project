using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [PrimaryKey(nameof(product_id), nameof(SKU))]
    public class Inventory
    {
        public int product_id { get; set; }
        [MaxLength(16)]
        public string SKU { get; set; }

        public string unit { get; set; }

        public int qty { get; set; }

        public string manufacturer { get; set; }

        public string shipping_time { get; set; }

        public double shipping_cost { get; set; }

        //Navigation property for a one to many relation with Products
        public Product Product { get; set; }

    }
}
