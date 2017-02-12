using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using XS156WebApi.Helper;

namespace XS156WebApi.Models.Persistence
{
    public class EquipmentReferenceProcessRepository : Repository<Xs156DbContext,EquipmentReferenceProcess>, IEquipmentReferenceProcessRepository
    {
        public  EquipmentReferenceProcess Get(Equipment equipment, ReferenceProcess referenceProcess)
        {
            IEquipmentRepository equipmentRepository = new EquipmentRepository();

            Equipment prevEquipment = equipmentRepository.GetPreviousEquipment(equipment);
            var reference = GetByProccessReference(referenceProcess, equipment);
            reference.ProcessAbleQuantity =
            GetByProccessReference(referenceProcess, prevEquipment).OutputQuantity;

            return reference;
        }

        public EquipmentReferenceProcess UpdateOutputQuantity(Guid equipmentProcessGuid, int value)
        {
            var erp = Get(equipmentProcessGuid.ToString());
            erp.OutputQuantity = value;
            erp.LastUpdated = DateTime.Now;
            Update(erp);
            return Get(equipmentProcessGuid.ToString());
        }

        public EquipmentReferenceProcess UpdateOutputQuantity(EquipmentReferenceProcess equipmentProcessGuid, int value)
        {
            var erp = Get(equipmentProcessGuid.Id.ToString());
            erp.OutputQuantity = value;
            erp.LastUpdated = DateTime.Now;
            Update(erp);
            return Get(equipmentProcessGuid.ToString());
        }

        public EquipmentReferenceProcess UpdateRejectedQuantity(EquipmentReferenceProcess equipmentProcessGuid, int value)
        {
            var erp = Get(equipmentProcessGuid.Id.ToString());
            erp.RejectedQuantity = value;
            erp.LastUpdated = DateTime.Now;
            Update(erp);
            return Get(equipmentProcessGuid.ToString());
        }

        public  EquipmentReferenceProcess  GetByProccessReference(ReferenceProcess referenceProcess, Equipment equipment)
        {
            IEnumerable<EquipmentReferenceProcess> result;
            IEquipmentReferenceProcessRepository session = new EquipmentReferenceProcessRepository();
           

             result = session.GetAll().ToList()
                        .Where(x => (x.Equipment == equipment.Id) && (x.ReferenceProcess == referenceProcess.ProcessGuid)).OrderBy(x => x.LastUpdated).Take(1);

              var equipmentReferenceProcesses = result as EquipmentReferenceProcess[] ?? result.ToArray();
            if (equipmentReferenceProcesses.Length<=0)
            return equipmentReferenceProcesses.First();
            else
            {
                return new EquipmentReferenceProcess();
            }
        }

        public EquipmentReferenceProcess GetPreviousEquipmentReferenceProces(string equipmentReferenceProcess)
        {
            var egcurrent = Get(equipmentReferenceProcess);
            IEquipmentRepository equipmentRepository = new EquipmentRepository();
            var data = equipmentRepository.GetPreviousEquipment(new Guid(egcurrent.Equipment.ToString()));
            return
                GetAll()
                    .First(
                        x => x.ReferenceProcess == egcurrent.ReferenceProcess && x.Equipment == data.Id);
        }

        public EquipmentReferenceProcess UpdateRejectedQuantity(Guid equipmentProcessGuid, int value)
        {
            var erp = Get(equipmentProcessGuid.ToString());
            erp.RejectedQuantity = value;
            erp.LastUpdated = DateTime.Now;
            Update(erp);
            return Get(equipmentProcessGuid.ToString());
        }
       
      
    }
}