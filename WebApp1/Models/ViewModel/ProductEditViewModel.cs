using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models.Entities;

namespace WebApp1.Models.ViewModel
{
    public class ProductEditViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        [StringLength(20)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Produktnavn må angis")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Pris må være numerisk")]
        public decimal? Price { get; set; }
        public List<Category> Categories { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
    }
}
