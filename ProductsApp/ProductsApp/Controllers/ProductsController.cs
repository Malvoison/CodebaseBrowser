using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        IProductRepositoy _repository;

        public ProductsController(IProductRepositoy repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _repository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
