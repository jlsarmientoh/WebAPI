using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebAPI.Adapters;
using WebAPI.Exceptions;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class ProductService : IProductService
    {
        private DataBaseModel db = new DataBaseModel();

        private IModelAdapter<Product, ProductModel> productModelAdapter = new ProductModelApdapter();

        public IEnumerable<ProductModel> getAllProducts()
        {
            try
            {
                IQueryable<Product> productos = db.Product;

                return productModelAdapter.AdaptAll(productos);
            }
            catch(Exception e)
            {
                string errorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
                throw new GetProductsException(errorMessage);
            }
            
        }

        public ProductModel getProductById(int id)
        {
            try
            {
                Product product = db.Product.Find(id);

                if (product == null)
                {
                    return null;
                }

                return productModelAdapter.AdaptTo(product);
            }
            catch(Exception e)
            {
                string errorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
                throw new GetProductsException(errorMessage);
            }
        }

        public ProductModel addProduct(ProductModel productModel)
        {
            try
            {
                Product product = productModelAdapter.AdaptTo(productModel);

                db.Product.Add(product);
                db.SaveChanges();

                productModel.Id = product.ProductID;
                return productModel;
            } catch(DbUpdateException e)
            {
                string errorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
                throw new CreateProductException(errorMessage);
            }
            
        }
    }
}