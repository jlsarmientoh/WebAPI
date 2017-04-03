using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Exceptions
{
    [Serializable]
    public class CreateProductException : Exception
    {
        public CreateProductException(string message) : base(message)
        {
        }
    }
}