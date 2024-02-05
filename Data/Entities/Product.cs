using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [PrimaryKey(nameof(Id),nameof(SKU))]
    public class Product
    {
        public int Id { get; set; }
        
        [MaxLength(16)]
        public string SKU { get; set; }

        public string name { get; set; }
        [MaxLength(13)]
        public string EAN { get; set; }

        public string producer_name { get; set; }

        public string category { get; set; }

        public bool is_wire { get; set; }

        public bool is_available { get; set; }

        public bool is_vendor { get; set; }

        public string default_image { get; set; }


        //Navigation property with collection of inventories (needed to create a relation with Inventory)
        public ICollection<Inventory> Inventories { get; set; }

        //Navigation property needed to create a one-to-one relation with Price table
        public Price Price { get; set; }



    }
}
