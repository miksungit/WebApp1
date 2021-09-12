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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            // Seeding
            modelBuilder.Entity<Product>()
            .HasData(new Product { ProductId = 1, Name = "Hammer", Price = 121.50m, Category = "Verktøy" });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 2, Name = "Vinkelsliper", Price = 1520.00m, Category = "Verktøy" });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 3, Name = "Volvo XC90", Price = 990000m, Category = " Kjøretøy" });
            modelBuilder.Entity<Product>().HasData(new Product
            { ProductId = 4, Name = "Volvo XC60", Price = 620000m, Category = "Kjøretøy" });
            modelBuilder.Entity<Product>()
            .HasData(new Product { ProductId = 5, Name = "Brød", Price = 25.50m, Category = "Dagligvarer" });
        }
    }
}
