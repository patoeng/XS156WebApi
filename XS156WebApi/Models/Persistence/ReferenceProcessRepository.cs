using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using XS156WebApi.Helper;

namespace XS156WebApi.Models.Persistence
{
    public class ReferenceProcessRepository : Repository<Xs156DbContext,ReferenceProcess>, IReferenceProcessRepository
    {
        private static readonly IEquipmentReferenceProcessRepository EquipmentReferenceProcessRepository = new EquipmentReferenceProcessRepository();
        public ReferenceProcess GetByGuid(Guid guid)
        {
            IEnumerable<ReferenceProcess> data = GetAll().Where(x => x.ProcessGuid ==guid).OrderByDescending(x=>x.ProcessGuid);
            return data.First();
        }

        public ReferenceProcess GetByOrderNumber(string ordernumber)
        {
            IEnumerable<ReferenceProcess> data = GetAll().Where(x => x.OrderNumber == ordernumber).OrderByDescending(x => x.ProcessGuid);
            return data.Single();
        }

        public IEnumerable<EquipmentReferenceProcess> GetEquipmentReferenceProcessess(ReferenceProcess referenceProcess)
        {
            IEquipmentLineGroupRepository equipmentGroupRepository = new EquipmentLineGroupRepository();
         
            IEquipmentRepository equipmentRepository = new EquipmentRepository();

            IEnumerable<EquipmentReferenceProcess> ff  = 
              EquipmentReferenceProcessRepository.GetAll()
                    .Where(x => x.ReferenceProcess == referenceProcess.ProcessGuid);

            var ffToArray = ff as EquipmentReferenceProcess[] ?? ff.ToArray();
            
            IEnumerable<Equipment> equipmentInGroup = equipmentGroupRepository.GetEquipmentMembers(equipmentGroupRepository.Get(referenceProcess.LineGroup.ToString()));

            var inGroup = equipmentInGroup as Equipment[] ?? equipmentInGroup.ToArray();

            var index = 0;
            foreach (EquipmentReferenceProcess equipmentReferenceProcess in ffToArray)
            {
                
                foreach (Equipment equi in inGroup)
                {
                   
                    if (equi.Id == equipmentReferenceProcess.Equipment)
                    {
                        var k = equipmentRepository.GetPreviousEquipment(equi);
                        if (k != null)
                        {
                            ffToArray[index].ProcessAbleQuantity =
                                EquipmentReferenceProcessRepository.GetByProccessReference(referenceProcess, k)
                                    .OutputQuantity;
                        }
                    }
                }
                index++;
            }
            return ffToArray;
        }

        public Guid CreateAllEquipmentProcess(ReferenceProcess processReference)
        {
            IEquipmentLineGroupRepository equipmentGroupRepository = new EquipmentLineGroupRepository();
            var q = equipmentGroupRepository.Get(processReference.LineGroup.ToString());
            var equipmentMembers = equipmentGroupRepository.GetEquipmentMembers(q);

            foreach (Equipment equipment in equipmentMembers)
            {
                var v = new EquipmentReferenceProcess
                {
                    Equipment = equipment.Id,
                    ReferenceProcess = processReference.ProcessGuid,
                    TargetQuantity = processReference.TargetQuantity,
                    LastUpdated = new DateTime()
                };
                EquipmentReferenceProcessRepository.Add(v);
            }
            return processReference.ProcessGuid;
        }

        public void Close(ReferenceProcess referenceProcess)
        {
            referenceProcess.IsClosed = true;
            Update(referenceProcess);
        }

        
      
    }
}