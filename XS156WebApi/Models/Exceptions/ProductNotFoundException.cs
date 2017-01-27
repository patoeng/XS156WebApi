using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException()
        {
        }

        public ProductNotFoundException(string message)
            : base(message)
        {
            
        }

        public ProductNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
        public ProductNotFoundException(string messsage, params object[] args)
        : base(string.Format(messsage, args)) { }

    }
}