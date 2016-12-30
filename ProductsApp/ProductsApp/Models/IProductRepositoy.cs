using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    public interface IProductRepositoy
    {
        IEnumerable<Product> GetAll();
        Product GetByID(int id);
        void Add(Product product);
    }
}
