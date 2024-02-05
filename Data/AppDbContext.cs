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

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Creates a one to many relationship between Product and Inventory table's
            modelBuilder.Entity<Inventory>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Inventories)
                .HasPrincipalKey(e => new { e.Id, e.SKU })
                .HasForeignKey(e => new { e.product_id, e.SKU });

            //Creates a one to one relationship between Product and Price table's
            modelBuilder.Entity<Product>()
                .HasOne<Price>(p => p.Price)
                .WithOne(p => p.Product)
                .HasPrincipalKey<Product>(p => new { p.Id, p.SKU })
                .HasForeignKey<Price>(p => new { p.ProductId, p.SKU });

            base.OnModelCreating(modelBuilder);
        }
    }
}
