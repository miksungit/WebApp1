using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public interface IProductRepositoryOld
    {
        IEnumerable<Entities.Product> GetAll();
    }
}
