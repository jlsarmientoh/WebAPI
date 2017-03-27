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
            Product product = new Product();
            product.Color = productModel.Color;
            product.DiscontinuedDate = productModel.DiscontinuedDate;
            product.ProductID = productModel.Id;
            product.ListPrice = productModel.ListPrice;
            product.Name = productModel.Name;
            product.ProductNumber = productModel.ProductNumber;
            product.SellEndDate = productModel.SellEndDate;
            product.SellStartDate = productModel.SellStartDate;
            product.Size = productModel.Size;
            product.StandardCost = productModel.StandardCost;
            product.ThumbNailPhoto = productModel.ThumbNailPhoto;
            product.Weight = productModel.Weight;

            return product;
        }

        private ProductModel AdaptSingleFromProduct(Product product)
        {
            ProductModel productModel = new ProductModel();
            productModel.Color = product.Color;
            productModel.DiscontinuedDate = product.DiscontinuedDate;
            productModel.Id = product.ProductID;
            productModel.ListPrice = product.ListPrice;
            productModel.Name = product.Name;
            productModel.ProductNumber = product.ProductNumber;
            productModel.SellEndDate = product.SellEndDate;
            productModel.SellStartDate = product.SellStartDate;
            productModel.Size = product.Size;
            productModel.StandardCost = product.StandardCost;
            productModel.ThumbNailPhoto = product.ThumbNailPhoto;
            productModel.Weight = product.Weight;

            return productModel;
        }
    }
}