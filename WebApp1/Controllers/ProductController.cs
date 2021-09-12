using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models.Entities;
using WebApp1.Models;
using WebApp1.Data;
using WebApp1.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

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
            var product = repository.GetProductEditViewModel();
            return View(product);
        }
        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind("Name,Description,Price,ManufacturerId,CategoryId")]ProductEditViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product product1 = new Product();
                    repository.Save(product1);
                    TempData["message"] = string.Format("{0} har blitt opprettet", product.Name);
                    return RedirectToAction("Index");
                }
                else 
                    return View();

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
            IEnumerable<Product> products = db.Products.Include("Category").Include("Manufacturer");
            return products;
        }


        public ProductEditViewModel GetProductEditViewModel()
        {
            List<Category> categories = (from o in db.Categories select o).ToList();
            List<Manufacturer> manufacturers = (from o in db.Manufacturers select o).ToList();

            ProductEditViewModel productEditViewModel = new ProductEditViewModel { Manufacturers = manufacturers, Categories = categories };

            return productEditViewModel;
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

        public ProductEditViewModel GetProductEditViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
