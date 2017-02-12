using System;
using System.Runtime.Serialization;



namespace XS156WebApi.Models
{   
  
    public class Equipment
    {
        public  Guid Id { get; set; }
        public  string EquipmentName { get; set; }

        public  string Description { get; set; }
      
        public EquipmentRole? Role { get; set; }

        public  Guid PreviousEquipment { get; set; }

        public  Guid EquipmentLineGroup { get; set; }
        public  EquipmentStatus? Status { get; set; }
    }
}