using System;

namespace XS156WebApi.Models
{
  
    public class ProductReference
    {
        public virtual Guid Id { get; set; }
       
        public virtual String ReferenceName { get; set; }

        public virtual int GroupingSize { get; set; }
        public virtual String Descriptions { get; set; }

    }
}