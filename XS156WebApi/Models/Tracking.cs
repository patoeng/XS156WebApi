using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Xml;
using XS156WebApi.Helper;
using XS156WebApi.Models.Persistence;

namespace XS156WebApi.Models
{
    public class Tracking : ITracking
    {
        private static readonly IReferenceProcessRepository ReferenceProcessRepository=  new ReferenceProcessRepository();
        private static readonly IEquipmentRepository EquipmentRepository = new EquipmentRepository();
        private static readonly IProductReferenceRepository ProductReferenceRepository = new ProductReferenceRepository();
        private static readonly IEquipmentLineGroupRepository EquipmentLineGroupRepository = new EquipmentLineGroupRepository();
        

        public TrackingData CreateNewTrackingData(ReferenceProcess referenceProcess, Guid initiatorEquipment)
        {
           var product = ProductReferenceRepository.Get(referenceProcess.ProductReference.ToString());

            referenceProcess.LineGroup = EquipmentRepository.Get(initiatorEquipment.ToString()).EquipmentLineGroup;
            var reference = new ReferenceProcess
            {
                ProcessGuid = Guid.NewGuid(),
                ProductReference = product.Id,
                LineGroup = referenceProcess.LineGroup,
                TargetQuantity = referenceProcess.TargetQuantity,
                EndDateTime =  DateTime.MaxValue,
                StartDateTime = DateTime.Now,
                OrderNumber = referenceProcess.OrderNumber
            };


            reference=ReferenceProcessRepository.Add(reference);
            var processGuid = ReferenceProcessRepository.CreateAllEquipmentProcess(reference);

            return new TrackingData()
            {
                ProductReference =  product,
                EquipmentReferenceProcesses = ReferenceProcessRepository.GetEquipmentReferenceProcessess(reference),
                ReferenceProcess = ReferenceProcessRepository.GetByGuid(processGuid)
            };
        }

        public TrackingData GetByGuid(Guid trackingGuid)
        {
            var referenceProcess = ReferenceProcessRepository.GetByGuid(trackingGuid);
            var product = ProductReferenceRepository.Get(referenceProcess.ProductReference.ToString())?? new ProductReference
            {
                Id= Guid.Empty,
                ReferenceName = ""
            };
          

            var data = new TrackingData()
            {
                ProductReference = product,
                EquipmentReferenceProcesses = ReferenceProcessRepository.GetEquipmentReferenceProcessess(referenceProcess),
                ReferenceProcess = ReferenceProcessRepository.GetByGuid(referenceProcess.ProcessGuid)
            };
            return data;
        }
        public TrackingData GetByOrderNumber(string ordernumber)
        {
            var referenceProcess = ReferenceProcessRepository.GetByOrderNumber(ordernumber);
            var product = ProductReferenceRepository.Get(referenceProcess.ProductReference.ToString()) ?? new ProductReference
            {
                Id = Guid.Empty,
                ReferenceName = ""
            };


            var data = new TrackingData()
            {
                ProductReference = product,
                EquipmentReferenceProcesses = ReferenceProcessRepository.GetEquipmentReferenceProcessess(referenceProcess),
                ReferenceProcess = ReferenceProcessRepository.GetByGuid(referenceProcess.ProcessGuid)
            };
            return data;
        }

        public TrackingData GetLastByLineGroup(EquipmentLineGroup equipmentLineGroup)
        {
            IReferenceProcessRepository session = new ReferenceProcessRepository();
         
                var references = session.GetAll()
                    .Where(x => x.LineGroup == equipmentLineGroup.Id)
                    .OrderByDescending(x => x.StartDateTime)
                    .Take(1);

                return GetByGuid(references.First().ProcessGuid);
            
        }
        public TrackingData GetLastByLineGroup(Guid equipmentLineGroup)
        {
            IReferenceProcessRepository session = new ReferenceProcessRepository();
            var references = session.GetAll().ToList()
                .Where(x => x.LineGroup == equipmentLineGroup)
                .OrderByDescending(x => x.StartDateTime)
                .Take(1);

                return GetByGuid(references.First().ProcessGuid);
            
        }
        public Guid GetLastByLineGroupS(Guid equipmentLineGroup)
        {
            IReferenceProcessRepository session = new ReferenceProcessRepository();
                var references = session.GetAll().ToList()
                    .Where(x => x.LineGroup == equipmentLineGroup)
                    .OrderByDescending(x => x.StartDateTime)
                    .Take(1)
                    .First();

                return references.ProcessGuid;
            
        }
        public TrackingData GetLastByEquipment(Equipment equipment)
        {
            var lineGroup = EquipmentLineGroupRepository.Get(equipment.EquipmentLineGroup.ToString());
            return GetLastByLineGroup(lineGroup);
        }

        public TrackingData GetLastByEquipment(Guid equipment)
        {
            var lineGroup = EquipmentLineGroupRepository.Get(equipment.ToString());
            return GetLastByLineGroup(lineGroup);
        }

        public IEnumerable<TrackingData> GetByLineGroup(EquipmentLineGroup equipmentLineGroup)
        {
            var data = new List<TrackingData>( );
           IReferenceProcessRepository session = new ReferenceProcessRepository();
                var references = session.GetAll()
                    .Where(x => x.LineGroup == equipmentLineGroup.Id)
                    .OrderByDescending(x => x.StartDateTime);

                data.AddRange(references.Select(referenceProcess => GetByGuid(referenceProcess.ProcessGuid)));

                return data;
            
        }

        public IEnumerable<TrackingData> GetByLineGroup(Guid equipmentLineGroup)
        {
            var data = new List<TrackingData>();
            IReferenceProcessRepository session = new ReferenceProcessRepository();
                var references = session.GetAll()
                    .Where(x => x.LineGroup == equipmentLineGroup)
                    .OrderByDescending(x => x.StartDateTime);

                data.AddRange(references.Select(referenceProcess => GetByGuid(referenceProcess.ProcessGuid)));

                return data;
            
        }

        public IEnumerable<TrackingData> GetByEquipment(Equipment equipment)
        {
            var lineGroup = EquipmentLineGroupRepository.Get(equipment.EquipmentLineGroup.ToString());
            return GetByLineGroup(lineGroup);
        }

        public IEnumerable<TrackingData> GetByEquipment(Guid equipment)
        {
            var lineGroup = EquipmentLineGroupRepository.Get(equipment.ToString());
            return GetByLineGroup(lineGroup);
        }

        public void Close(ReferenceProcess referenceProcess)
        {
            var gg = ReferenceProcessRepository.Get(referenceProcess.ProcessGuid.ToString());
            gg.IsClosed = true;
            ReferenceProcessRepository.Update(gg);
        }

        public void Close(Guid referenceProcess)
        {
            var gg = ReferenceProcessRepository.Get(referenceProcess.ToString());
            gg.IsClosed = true;
            ReferenceProcessRepository.Update(gg);
        }

       
    }
}