using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models.Persistence
{
    public class EquipmentLineGroupRepository : Repository<EquipmentLineGroup>, IEquipmentLineGroupRepository
    {
        public IEnumerable<Equipment> GetEquipmentMembers(EquipmentLineGroup lineGroup)
        {
            IEquipmentRepository equipmentRepository = new EquipmentRepository();
            return equipmentRepository.GetAll().Where(x => (x.EquipmentLineGroup == lineGroup.Id)&& (x.Status==EquipmentStatus.Active));
        }

     
    }
}