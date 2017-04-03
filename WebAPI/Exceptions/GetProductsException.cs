using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Exceptions
{
    [Serializable]
    public class GetProductsException : Exception
    {
        public GetProductsException(string message) : base(message)
        {
        }
    }
}