using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models.ViewModel;

namespace WebApp1.Models.Entities
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Save(Product product);
        ProductEditViewModel GetProductEditViewModel();
    }
}
