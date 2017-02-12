using System;

namespace XS156WebApi.Models
{
   
    public class EquipmentReferenceProcess
    {
     
        public  Guid Id { get; set; }
        public  Guid Equipment { get; set; }

        public  Guid ReferenceProcess { get; set; }

        public  int ProcessAbleQuantity { get; set; }

        public  int OutputQuantity { get; set; }

        public  int RejectedQuantity { get; set; }

        public  DateTime LastUpdated { get; set; }
        public  int TargetQuantity { get; set; }

        public  int QuantityLeftToProcess { get; set; }
        public  bool Completed { get; set; }
    }
}