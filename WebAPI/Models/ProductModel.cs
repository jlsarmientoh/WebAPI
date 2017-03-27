using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string ProductNumber { get; set; }
        
        public string Color { get; set; }
        
        public decimal StandardCost { get; set; }
        
        public decimal ListPrice { get; set; }
        
        public string Size { get; set; }

        public decimal? Weight { get; set; }

        public DateTime SellStartDate { get; set; }

        public DateTime? SellEndDate { get; set; }

        public DateTime? DiscontinuedDate { get; set; }

        public byte[] ThumbNailPhoto { get; set; }
    }
}