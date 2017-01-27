using System;
using System.Runtime.Serialization;
using Remotion.Linq;


namespace XS156WebApi.Models
{   
  
    public class Equipment
    {
        public virtual Guid Id { get; set; }
        public virtual string EquipmentName { get; set; }

        public virtual string Description { get; set; }
      
        public virtual EquipmentRole Role { get; set; }

        public virtual Guid PreviousEquipment { get; set; }

        public virtual Guid EquipmentLineGroup { get; set; }
        public virtual EquipmentStatus Status { get; set; }
    }
}