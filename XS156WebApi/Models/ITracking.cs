using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models
{
    public interface ITracking
    {
        TrackingData CreateNewTrackingData(ReferenceProcess referenceProcess, Guid initiatorEquipment);
        TrackingData GetByGuid(Guid trackingGuid);
        TrackingData GetLastByLineGroup(EquipmentLineGroup equipmentLineGroup);
        TrackingData GetLastByLineGroup(Guid equipmentLineGroup);
        TrackingData GetLastByEquipment(Equipment equipment);
        TrackingData GetLastByEquipment(Guid equipment);
        IEnumerable<TrackingData> GetByLineGroup(EquipmentLineGroup equipmentLineGroup);
        IEnumerable<TrackingData> GetByLineGroup(Guid equipmentLineGroup);
        IEnumerable<TrackingData> GetByEquipment(Equipment equipment);
        IEnumerable<TrackingData> GetByEquipment(Guid equipment);
        void Close(ReferenceProcess referenceProcess);
        void Close(Guid referenceProcess);
        Guid GetLastByLineGroupS(Guid equipmentLineGroup);
        TrackingData GetByOrderNumber(string id);
    }
}