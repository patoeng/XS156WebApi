using System;

namespace XS156WebApi.Models
{
  
    public class ProductReference
    {
        public  Guid Id { get; set; }
       
        public  String ReferenceName { get; set; }

        public  int? GroupingSize { get; set; }
        public  String Descriptions { get; set; }

    }
}