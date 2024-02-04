using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Price> Prices { get; set; }

        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "database.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source ={DbPath}");
    }
}
