using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models.Persistence
{
    public interface IReferenceProcessRepository : IRepository<ReferenceProcess>
    {
        IEnumerable<EquipmentReferenceProcess> GetEquipmentReferenceProcessess(ReferenceProcess referceProces);
        Guid CreateAllEquipmentProcess(ReferenceProcess processReference);
        void Close(ReferenceProcess referenceProcess);
        ReferenceProcess GetByGuid(Guid guid);
        ReferenceProcess GetByOrderNumber(string ordernumber);
    }
}