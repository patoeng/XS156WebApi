using System;
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
    [RoutePrefix("api/equipmentgroup")]
    public class EquipmentLineGroupController : ApiController{

    static readonly IEquipmentLineGroupRepository EquipmentGroupRepository = new EquipmentLineGroupRepository();

        [ActionName("GetAll")]
        [Route("", Name = "GetEquipmentGroupAll")]
        public IHttpActionResult GetEquipments()
        {
             IEnumerable<EquipmentLineGroup> data = EquipmentGroupRepository.GetAll();
             return Ok(data);
        }


        [ActionName("GetByGuid")]
        [Route("{id}", Name = "GetEquipmentGroupByGuid")]
        public IHttpActionResult GetServerDataById(string id)
        {
            var equipment = EquipmentGroupRepository.Get(id);

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }
        [ActionName("GetEquipmentMembers")]
        [Route("GetEquipmentMembers/{id}", Name = "GetEquipmentMembers")]
        public IHttpActionResult GetEquipmentMembers(Guid id)
        {

            var lineGroup = EquipmentGroupRepository.GetEquipmentMembers(EquipmentGroupRepository.Get(id.ToString()));

            if (lineGroup == null)
                return NotFound();

            return Ok(lineGroup);
        }
      
   
        [HttpPost]
        [ActionName("Add")]
        [Route("")]
        public IHttpActionResult Post([FromBody] EquipmentLineGroup equipment)
        {
            if (equipment == null)
            {
                return BadRequest("Equipment cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            equipment = EquipmentGroupRepository.Add(equipment);

            return CreatedAtRoute("GetEquipmentGroupByGuid", new { id = equipment.Id }, equipment);

        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(string id, [FromBody]  EquipmentLineGroup equipment)
        {
            equipment.Id = new Guid(id);

            if (!EquipmentGroupRepository.Update(equipment))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

       [HttpDelete]
       [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            var serverData = EquipmentGroupRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            EquipmentGroupRepository.Delete(serverData);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }
    }
}
