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
                var path = "C:/Users/bigie/Downloads/Products.csv";
                SaveFileLocally(path, "Products.csv");

                var products = ReadProducts(path);

                var filtered = products.Where(n => !n.category.Contains("kable"));
                
            }
            catch (Exception ex)
            {

            }
            return View();
        }


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

        private void SaveFileLocally(string sourceFilePath, string destinationFileName)
        {
            var destinationFilePath = $"C:/{destinationFileName}";
            System.IO.File.Copy(sourceFilePath, destinationFilePath, true);
        }
    }
}
