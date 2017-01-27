using System;

namespace XS156WebApi.Models
{
   
    public class EquipmentReferenceProcess
    {
     
        public virtual Guid Id { get; set; }
        public virtual Guid Equipment { get; set; }

        public virtual Guid ReferenceProcess { get; set; }

        public virtual int ProcessAbleQuantity { get; set; }

        public virtual int OutputQuantity { get; set; }

        public virtual int RejectedQuantity { get; set; }

        public virtual DateTime LastUpdated { get; set; }
        public virtual int TargetQuantity { get; set; }

        public virtual int QuantityLeftToProcess { get; set; }
        public virtual bool Completed { get; set; }
    }
}