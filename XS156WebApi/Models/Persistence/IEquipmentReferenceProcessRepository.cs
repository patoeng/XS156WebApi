using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models.Persistence
{
    public interface IEquipmentReferenceProcessRepository : IRepository<EquipmentReferenceProcess>
    {
        EquipmentReferenceProcess Get(Equipment equipment, ReferenceProcess referenceProcess);
        EquipmentReferenceProcess UpdateOutputQuantity(Guid equipmentProcessGuid, int value);
        EquipmentReferenceProcess UpdateOutputQuantity(EquipmentReferenceProcess equipmentProcessGuid, int value);
        EquipmentReferenceProcess UpdateRejectedQuantity(Guid equipmentProcessGuid, int value);
        EquipmentReferenceProcess UpdateRejectedQuantity(EquipmentReferenceProcess equipmentProcessGuid, int value);
        EquipmentReferenceProcess GetByProccessReference(ReferenceProcess referenceProcess, Equipment equipment);
        EquipmentReferenceProcess GetPreviousEquipmentReferenceProces(string equipmentReferenceProcess);
    }
}