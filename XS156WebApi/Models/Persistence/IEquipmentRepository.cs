using System;
using System.Collections.Generic;

namespace XS156WebApi.Models.Persistence
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Equipment GetPreviousEquipment(Equipment equipment);
        Equipment GetNextEquipment(Equipment get);
        Equipment GetPreviousEquipment(Guid equipment);
    }
}