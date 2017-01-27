using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace XS156WebApi.Models.Persistence
{
    public interface IEquipmentLineGroupRepository : IRepository<EquipmentLineGroup>
    {
        IEnumerable<Equipment> GetEquipmentMembers(EquipmentLineGroup lineGroup);
    }
}