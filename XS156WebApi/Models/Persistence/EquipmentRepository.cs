using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using XS156WebApi.Helper;

namespace XS156WebApi.Models.Persistence
{
    public class EquipmentRepository : Repository<Xs156DbContext,Equipment>, IEquipmentRepository
        {
            public Equipment GetPreviousEquipment(Equipment equipment)
            {
               return  Get(equipment.PreviousEquipment.ToString());
            }
            public Equipment GetPreviousEquipment(Guid equipment)
            {
                var gg = Get(equipment.ToString()).PreviousEquipment;
                return Get(gg.ToString());
            }

            public Equipment GetNextEquipment(Equipment equipment)
            {
                IEquipmentRepository session = new EquipmentRepository();
               
                    return session.GetAll().ToList().Where(x => x.PreviousEquipment == equipment.Id && x.Status==EquipmentStatus.Active).Take(1)
                        .First();
            }
        }
    
}