using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(16)]
        public string SKU { get; set; }

        public string unit { get; set; }

        public int qty { get; set; }

        public string manufacturer { get; set; }

        public string shipping_time { get; set; }

        public double shipping_cost { get; set; }
    }
}
