using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Adapters
{
    public class ProductModelApdapter : IModelAdapter<Product, ProductModel>
    {
        public IEnumerable<Product> AdaptAll(IEnumerable<ProductModel> productModelList)
        {
            List<Product> productList = new List<Product>();

            if (productModelList != null)
            {
                foreach(ProductModel productModel in productModelList)
                {
                    productList.Add(AdaptSingleFromProductModel(productModel));
                }
            }

            return productList;
        }

        public IEnumerable<ProductModel> AdaptAll(IEnumerable<Product> productList)
        {
            List<ProductModel> productModelList = new List<ProductModel>();

            if (productList != null)
            {
                foreach (Product product in productList)
                {
                    productModelList.Add(AdaptSingleFromProduct(product));
                }
            }

            return productModelList;
        }

        public Product AdaptTo(ProductModel productModel)
        {
            return AdaptSingleFromProductModel(productModel);
        }

        public ProductModel AdaptTo(Product product)
        {
            return AdaptSingleFromProduct(product);
        }

        private Product AdaptSingleFromProductModel(ProductModel productModel)
        {
            Product product = new Product()
            {
                Color = productModel.Color,
                DiscontinuedDate = productModel.DiscontinuedDate,
                ProductID = productModel.Id,
                ListPrice = productModel.ListPrice,
                Name = productModel.Name,
                ProductNumber = productModel.ProductNumber,
                SellEndDate = productModel.SellEndDate,
                SellStartDate = productModel.SellStartDate,
                Size = productModel.Size,
                StandardCost = productModel.StandardCost,
                ThumbNailPhoto = productModel.ThumbNailPhoto,
                Weight = productModel.Weight,
                ProductCategoryID = 1,
                ProductModelID = 1
            };

            return product;
        }

        private ProductModel AdaptSingleFromProduct(Product product)
        {
            ProductModel productModel = new ProductModel()
            {
                Color = product.Color,
                DiscontinuedDate = product.DiscontinuedDate,
                Id = product.ProductID,
                ListPrice = product.ListPrice,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                SellEndDate = product.SellEndDate,
                SellStartDate = product.SellStartDate,
                Size = product.Size,
                StandardCost = product.StandardCost,
                ThumbNailPhoto = product.ThumbNailPhoto,
                Weight = product.Weight
            };

            return productModel;
        }
    }
}