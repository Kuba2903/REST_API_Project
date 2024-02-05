using CsvHelper;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Controllers
{
    [ApiController]
    public class ImportController : Controller
    {
        private readonly AppDbContext context;

        public ImportController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost("importProducts")]
        public IActionResult ImportProducts()
        {
            try
            {
                var products_path = "C:/Users/bigie/Downloads/Products.csv";

                SaveFileLocally(products_path, "Products.csv");

                var products = ReadProducts(products_path);

                var filteredProducts = products.Where(p => !p.category.Contains("kable")).ToList();
                //gets the products that are not cables

                context.Products.AddRange(filteredProducts);

                context.SaveChanges();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Successfull Import");
        }

        [HttpPost("importInventory")]
        public IActionResult ImportInventory()
        {
            try
            {
                var inventory_path = "C:/Users/bigie/Downloads/Inventory.csv";
                
                SaveFileLocally(inventory_path, "Inventory.csv");
                
                var inventory = ReadInventory(inventory_path);
                
                var filteredInventory = inventory.Where(i => i.shipping_time.Contains("24")).ToList();
                //gets only the inventory fields with shipping time up to 24 hours
                
                context.Inventory.AddRange(filteredInventory);
                
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Successfull Import");
        }


        [HttpPost("importPrices")]
        public IActionResult ImportPrices()
        {
            try
            {
                var price_path = "C:/Users/bigie/Downloads/Prices.csv";
                
                SaveFileLocally(price_path, "Prices.csv");
                
                var price = ReadPrice(price_path);
                
                context.Prices.AddRange(price);

                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Successfull Import");
        }

        /// <summary>
        /// Converts the file from csv file path to the List of products
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<Product> ReadProducts(string path)
        {
            var products = new List<Product>();

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                products = csv.GetRecords<Product>().ToList();
            }

            return products;
        }

        /// <summary>
        /// Converts the file from csv file path to the List of Inventories
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<Inventory> ReadInventory(string path)
        {
            var inventory = new List<Inventory>();

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                inventory = csv.GetRecords<Inventory>().ToList();
            }

            return inventory;
        }
        /// <summary>
        /// Converts the file from csv file path to the List of Prices
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<Price> ReadPrice(string path)
        {
            var price = new List<Price>();

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                price = csv.GetRecords<Price>().ToList();
            }

            return price;
        }

        private void SaveFileLocally(string sourceFilePath, string destinationFileName)
        {
            var destinationFilePath = $"C:/{destinationFileName}";
            System.IO.File.Copy(sourceFilePath, destinationFilePath, true); //copies the file from its source path to the destination provided
        }
    }
}
