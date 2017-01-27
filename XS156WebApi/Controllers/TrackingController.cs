using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XS156WebApi.Models;
using XS156WebApi.Models.Persistence;

namespace XS156WebApi.Controllers
{
    [RoutePrefix("api/tracking")]
    public class TrackingController : ApiController
    {
        private static readonly ITracking TrackingRepository = new Tracking();

        [ActionName("GetTestHello")]
        [Route("GetTestHello", Name = "GetTestHello")]
        public IHttpActionResult GetTestHello()
        {
            return Ok("Welcome!");
        }

        [ActionName("GetByGuid")]
        [Route("{id}", Name = "GetTrackingByGuid")]
        public IHttpActionResult GetTrackingByGuid(string id)
        {
            var guid = new Guid(id.ToLower());
            var tracking = TrackingRepository.GetByGuid(guid);

            if (tracking == null)
                return NotFound();

            return Ok(tracking);
        }
        [ActionName("GetByOrderNumber")]
        [Route("GetByOrderNumber/{id}", Name = "GetByOrderNumber")]
        public IHttpActionResult GetByOrderNumber(string id)
        {
            var tracking = TrackingRepository.GetByOrderNumber(id);

            if (tracking == null)
                return NotFound();

            return Ok(tracking);
        }

        [ActionName("GetByLineGroup")]
        [Route("GetByLineGroup/")]
        public IHttpActionResult GetByLineGroup(Guid equipmentLineGroup )
        {
            var tracking = TrackingRepository.GetByLineGroup(equipmentLineGroup);

            if (tracking == null)
                return NotFound();

            return Ok(tracking);
        }

        [ActionName("GetLastByLineGroup")]
        [Route("GetLastByLineGroup/{equipmentLineGroup}")]
        public IHttpActionResult GetLastByLineGroup(Guid equipmentLineGroup)
        {
            var tracking = TrackingRepository.GetLastByLineGroup(equipmentLineGroup);

            if (tracking == null)
                return NotFound();

            return Ok(tracking);
        }
        [ActionName("GetLastByLineGroupS")]
        [Route("GetLastByLineGroupS/{equipmentLineGroup}")]
        public IHttpActionResult GetLastByLineGroupS(Guid equipmentLineGroup)
        {
            var tracking = TrackingRepository.GetLastByLineGroupS(equipmentLineGroup);

            if (tracking == Guid.Empty)
                return NotFound();

            return Ok(tracking);
        }

        [ActionName("GetByEquipment")]
        [Route("GetByEquipment/{equipment}")]
        public IHttpActionResult GetByEquipment(Guid equipment)
        {
            var tracking = TrackingRepository.GetByEquipment(equipment);

            if (tracking == null)
                return NotFound();

            return Ok(tracking);
        }

        [ActionName("GetLastByEquipment")]
        [Route("GetLastByEquipment/{equipment}")]
        public IHttpActionResult GetLastByEquipment(Guid equipment)
        {
            var tracking = TrackingRepository.GetLastByEquipment(equipment);

            if (tracking == null)
                return NotFound();

            return Ok(tracking);
        }

        [HttpPost]
        [ActionName("Add")]
        [Route("{initiator}")]
        public IHttpActionResult PostTracking([FromBody] ReferenceProcess referenceProcess,Guid initiator)
        {
            if (referenceProcess == null)
            {
                return BadRequest("Equipment cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tracking = TrackingRepository.CreateNewTrackingData(referenceProcess,initiator);

            var j = CreatedAtRoute("GetTrackingByGuid", new { id =tracking.ReferenceProcess.ProcessGuid}, tracking);
            return j;
        }
        [HttpPut]
        [ActionName("UpdateRejected")]
        [Route("UpdateRejected/{eqprocess:int}")]
        public IHttpActionResult PutUpdateRejected([FromBody] EquipmentReferenceProcess referenceProcess, int eqprocess)
        {
            if (referenceProcess == null)
            {
                return BadRequest("Equipment Process cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEquipmentReferenceProcessRepository equipmentReferenceProcessRepository = new EquipmentReferenceProcessRepository();

            var tracking = equipmentReferenceProcessRepository.UpdateRejectedQuantity(referenceProcess, eqprocess);

            return Ok(tracking);

        }
        [HttpPut]
        [ActionName("UpdateOutput")]
        [Route("UpdateOutput/{eqprocess:int}")]
        public IHttpActionResult PutUpdateOutput([FromBody] EquipmentReferenceProcess referenceProcess, int eqprocess)
        {
            if (referenceProcess == null)
            {
                return BadRequest("Equipment Process cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEquipmentReferenceProcessRepository equipmentReferenceProcessRepository = new EquipmentReferenceProcessRepository();

            var tracking = equipmentReferenceProcessRepository.UpdateOutputQuantity(referenceProcess, eqprocess);

            return Ok(tracking);

        }
        [HttpPut]
        [ActionName("Close")]
        [Route("Close/")]
        public IHttpActionResult PutClose([FromBody] ReferenceProcess referenceProcess)
        {
            if (referenceProcess == null)
            {
                return BadRequest("Equipment Process cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


           TrackingRepository.Close(referenceProcess);

            return Ok();

        }
        [HttpPut]
        [ActionName("Close")]
        [Route("Close/{referenceProcess}")]
        public IHttpActionResult PutClose(Guid referenceProcess)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrackingRepository.Close(referenceProcess);
            return Ok();

        }
    }
}
