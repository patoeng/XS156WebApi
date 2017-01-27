using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models
{
    public class TrackingData
    {
        public ProductReference ProductReference { get;  set; }
        public IEnumerable<EquipmentReferenceProcess> EquipmentReferenceProcesses { get; set; }
        public ReferenceProcess ReferenceProcess { get; set; }
       
    }
}