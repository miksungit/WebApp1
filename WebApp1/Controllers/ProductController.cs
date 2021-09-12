using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models.Entities;
using WebApp1.Models;
using WebApp1.Data;

namespace WebApp1.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            var products = repository.GetAll();
            return View(products);
        }
        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product Product)
        {
            try
            {
                // Kall til metoden save i repository
                var product = Product;
                repository.Save(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = db.Products;
            return db.Products;
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeProductRepository : IProductRepository
    {
        IEnumerable<Product> IProductRepository.GetAll()
        {
            List<Product> products = new List<Product>{
                new Product {Name="Hammer", Price=121.50m, Class="Verktøy"},
                new Product {Name="Vinkelsliper", Price=1520.00m, Class="Verktøy"},
                new Product {Name="Melk", Price=14.50m, Class="Dagligvarer"},
                new Product {Name="Kjøttkaker", Price=32.00m, Class="Dagligvarer"},
                new Product {Name="Brød", Price=25.50m, Class="Dagligvarer"}
             };
            return products;
        }
        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
