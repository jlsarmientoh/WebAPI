using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Collections;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(WebAPI.Models.ProductResponse))]

namespace WebAPI.Models
{
    public class ProductResponse
    {
        public int TotalResults { get; set; }

        public IEnumerable<ProductModel> Results { get; set; }
    }
}
