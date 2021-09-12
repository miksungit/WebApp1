using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using WebApp1.Controllers;
using WebApp1.Models.Entities;
using Moq;

namespace ProductUnitTest
{

    [TestClass]
    public class ProductControllerTest
    {
        Mock<IProductRepository> _repository;
        [TestMethod]
        public void IndexReturnsAllProducts()
        {
            // Arrange
            _repository = new Mock<IProductRepository>();
            List<Product> fakeproducts = new List<Product>{
                new Product {Name="Hammer", Price=121.50m, Description="Verkt�y"},
                new Product {Name="Vinkelsliper", Price=1520.00m, Description="Verkt�y"},
                new Product {Name="Melk", Price=14.50m, Description="Dagligvarer"},
                new Product {Name="Kj�ttkaker", Price=32.00m, Description="Dagligvarer"},
                new Product {Name="Br�d", Price=25.50m, Description="Dagligvarer"}
};
            _repository.Setup(x => x.GetAll()).Returns(fakeproducts);
            var controller = new ProductController(_repository.Object);
            // Act
            var result = (ViewResult)controller.Index();
            // Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model,
            typeof(Product));
            Assert.IsNotNull(result, "View Result is null");
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number of products");
        }
        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        {
            // Arrange
            _repository = new Mock<IProductRepository>();
            _repository.Setup(x => x.Save(It.IsAny<Product>()));
            var controller = new ProductController(_repository.Object);
            // Act
            //var result = controller.Create(new Product());
            // Assert
            _repository.VerifyAll();
            // test p� at save er kalt et bestemt antall ganger
            //_repository.Verify(x => x.save(It.IsAny<Product>()), Times.Exactly(1));
        }
    }

}