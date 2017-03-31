using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Service
{
    public interface IProductService
    {
        ProductModel addProduct(ProductModel productModel);
        IEnumerable<ProductModel> getAllProducts();
        ProductModel getProductById(int id);
    }
}