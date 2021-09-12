using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models.Entities;

namespace WebApp1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");


            // Seeding
            modelBuilder.Entity<Category>()
            .HasData(new Category { CategoryId = 1, Name = "Verktøy", Description = "Test1" });
            modelBuilder.Entity<Category>()
            .HasData(new Category { CategoryId = 2, Name = "Kjøretøy", Description = "Test2" });
            modelBuilder.Entity<Category>()
            .HasData(new Category { CategoryId = 3, Name = "Dagligvarer", Description = "Test3" });

            modelBuilder.Entity<Manufacturer>()
            .HasData(new Manufacturer { ManufacturerId = 1, Name = "Fiskars", Description = "Test1" });
            modelBuilder.Entity<Manufacturer>()
            .HasData(new Manufacturer { ManufacturerId = 2, Name = "Bosch", Description = "Test2" });
            modelBuilder.Entity<Manufacturer>()
            .HasData(new Manufacturer { ManufacturerId = 3, Name = "Myklevold", Description = "Test3" });
            modelBuilder.Entity<Manufacturer>()
            .HasData(new Manufacturer { ManufacturerId = 4, Name = "Volvo", Description = "Test4" });

            modelBuilder.Entity<Product>()
            .HasData(new Product { ProductId = 1, Name = "Hammer", Price = 121.50m, CategoryId = 1, ManufacturerId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 2, Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 1, ManufacturerId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 3, Name = "Volvo XC90", Price = 990000m, CategoryId = 2, ManufacturerId = 4 });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 4, Name = "Volvo XC60", Price = 620000m, CategoryId = 2, ManufacturerId = 4 });
            modelBuilder.Entity<Product>()
            .HasData(new Product { ProductId = 5, Name = "Brød", Price = 25.50m, CategoryId = 3, ManufacturerId = 3 });
        }
    }
}
