using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using XS156WebApi.Models;
using XS156WebApi.Models.Persistence;

namespace XS156WebApi.Controllers
{
   
    [RoutePrefix("api/equipment")]
    public class EquipmentController : ApiController
    {
        private IEquipmentRepository _equipmentDataRepository;

        public EquipmentController(IEquipmentRepository equipmentDataRepository)
        {
            _equipmentDataRepository = equipmentDataRepository;
        }

        [ActionName("GetAll")]
        [Route("", Name = "GetEquipmentAll")]
        public IHttpActionResult GetEquipments()
        {
             IEnumerable<Equipment> data = _equipmentDataRepository.GetAll();
             return Ok(data);
        }


        [ActionName("GetByGuid")]
        [Route("{id}", Name = "GetEquipmentByGuid")]
        public IHttpActionResult GetEquipmentByGuid(string id)
        {
            var equipment = _equipmentDataRepository.Get(id);

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        [ActionName("GetByRole")]
        [Route("getbyrole/{role}", Name = "GetEquipmentByRole")]
        public IHttpActionResult GetEquipmentByRole(EquipmentRole role)
        {
           IEnumerable<Equipment> data = _equipmentDataRepository.GetAll().Where(d => d.Role == role);
            return Ok(data);
        }


        
   
        [HttpPost]
        [ActionName("Add")]
        [Route("")]
        public IHttpActionResult PostEquipment([FromBody] Equipment equipment)
        {
            if (equipment == null)
            {
                return BadRequest("Equipment cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            equipment = _equipmentDataRepository.Add(equipment);

            return CreatedAtRoute("GetEquipmentByGuid", new { id = equipment.Id }, equipment);

        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult PutEquipment(string id, [FromBody] Equipment equipment)
        {
            equipment.Id = new Guid(id);

            if (!_equipmentDataRepository.Update(equipment))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

       [HttpDelete]
       [Route("{id}")]
        public IHttpActionResult DeleteEquipment(string id)
        {
            var serverData = _equipmentDataRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _equipmentDataRepository.Delete(serverData);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }
    }
    
}
