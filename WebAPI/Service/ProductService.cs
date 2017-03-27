using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Adapters;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class ProductService
    {
        private DataBaseModel db = new DataBaseModel();

        private IModelAdapter<Product, ProductModel> productModelAdapter = new ProductModelApdapter();

        public IEnumerable<ProductModel> getAllProducts()
        {
            IQueryable<Product> productos = db.Product;

            return productModelAdapter.AdaptAll(productos);
        }

        public ProductModel getProductById(int id)
        {
            Product product = db.Product.Find(id);

            if (product == null)
            {
                return null;
            }

            return productModelAdapter.AdaptTo(product);
        }

        public void addProduct(ProductModel productModel)
        {
            Product product = productModelAdapter.AdaptTo(productModel);

            db.Product.Add(product);
            db.SaveChanges();
        }
    }
}