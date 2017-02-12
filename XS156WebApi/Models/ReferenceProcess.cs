using System;

namespace XS156WebApi.Models
{
 
    public class ReferenceProcess
    {
     
        public  int Id { get; set; }
      
        public  Guid ProcessGuid { get; set; }
       
        public  Guid ProductReference { get; set; }
        
       
        public  Guid LineGroup { get; set; }
        
        public  int TargetQuantity { get; set; }
       
        public  DateTime StartDateTime { get; set; }
       
        public  DateTime EndDateTime { get; set; }
       
        public  bool IsClosed { get; set; }
        public  string OrderNumber { get; set; }
    }
}