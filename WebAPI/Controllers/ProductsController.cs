using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Service;


namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private IProductService productService = new ProductService();

        // GET: api/Products
        [ResponseType(typeof(ProductResponse))]
        public IHttpActionResult GetProduct(int fromIndex, int maxResults)
        {
            try
            {
                return Ok(productService.getAllProducts(fromIndex, maxResults));
            }
            catch(GetProductsException e)
            {
                return InternalServerError(e);
            }
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductResponse))]
        public IHttpActionResult GetProduct(int id)
        {
            try
            {
                ProductResponse product = productService.getProductById(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch(GetProductsException e)
            {
                return InternalServerError(e);
            }
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