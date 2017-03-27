using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductService productService = new ProductService();

        // GET: api/Products
        public IEnumerable<ProductModel> GetProduct()
        {
            return productService.getAllProducts();
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult GetProduct(int id)
        {
            ProductModel product = productService.getProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult PostProduct(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productService.addProduct(product);

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }
    }
}