using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using XS156WebApi.Helper;

namespace XS156WebApi.Models.Persistence
{
        public class EquipmentRepository : Repository<Equipment> ,IEquipmentRepository
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
                using (var session = NHibernateHelper.OpenSession())
                    return session.Query<Equipment>().ToList().Where(x => x.PreviousEquipment == equipment.Id && x.Status==EquipmentStatus.Active).Take(1)
                        .First();
            }
        }
    
}