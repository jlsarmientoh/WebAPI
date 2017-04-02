using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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

        public ProductResponse getAllProducts(int fromIndex, int maxResults)
        {
            try
            {
                IOrderedQueryable<Product> orderedProducts = db.Product.OrderBy(p => p.ListPrice);
                IQueryable<Product> products = orderedProducts.Skip(fromIndex).Take(maxResults);
                

                ProductResponse productsResult = new ProductResponse()
                {
                    TotalResults = orderedProducts.Count(),
                    Results = productModelAdapter.AdaptAll(products)
                };

                return productsResult;
            }
            catch(Exception e)
            {
                string errorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
                throw new GetProductsException(errorMessage);
            }
            
        }

        public ProductResponse getProductById(int id)
        {
            try
            {
                Product product = db.Product.Find(id);

                if (product == null)
                {
                    return null;
                }

                ProductResponse productsResult = new ProductResponse()
                {
                    TotalResults = 0,
                    Results = new List<ProductModel>() { productModelAdapter.AdaptTo(product) }
                };

                return productsResult;
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
            } catch(Exception e)
            {
                string errorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
                throw new CreateProductException(errorMessage);
            }
            
        }
    }
}