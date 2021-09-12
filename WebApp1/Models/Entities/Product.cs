using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Price { get; set; }
        //Navigational Properties
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}