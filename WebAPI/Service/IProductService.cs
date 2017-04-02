using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Service
{
    public interface IProductService
    {
        ProductModel addProduct(ProductModel productModel);
        ProductResponse getAllProducts(int fromIndex, int maxResults);
        ProductResponse getProductById(int id);
    }
}