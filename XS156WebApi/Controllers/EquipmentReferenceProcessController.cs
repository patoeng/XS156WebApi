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
    [RoutePrefix("api/EquipmentReferenceProcess")]
    public class EquipmentReferenceProcessController : ApiController
    {
        private static readonly IEquipmentReferenceProcessRepository EquipmentReferenceProcessDataRepository = new EquipmentReferenceProcessRepository();
       
        [ ActionName("GetAll")]
        [Route("", Name = "GetEquipmentReferenceProcessAll")]
        public IHttpActionResult Get()
        {
            IEnumerable<EquipmentReferenceProcess> data = EquipmentReferenceProcessDataRepository.GetAll();
             return Ok(data);
        }


        [ActionName("GetByGuid")]
        [Route("{id}", Name = "GetEquipmentReferenceProcessByGuid")]
        public IHttpActionResult Get(string id)
        {
            var equipment = EquipmentReferenceProcessDataRepository.Get(id);

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }
        [ActionName("GetPrevById")]
        [Route("GetPrevById/{id}", Name = "GetPreviousEquipmentReferenceProcess")]
        public IHttpActionResult GetPrev(string id)
        {
            var equipment = EquipmentReferenceProcessDataRepository.GetPreviousEquipmentReferenceProces(id);

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }
       

        [HttpPost]
        [ActionName("Add")]
        [Route("")]
        public IHttpActionResult Post([FromBody] EquipmentReferenceProcess product)
        {
            if (product == null)
            {
                return BadRequest("Equipment cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product = EquipmentReferenceProcessDataRepository.Add(product);

            return CreatedAtRoute("GetEquipmentReferenceProcessByGuid", new { id = product.Id }, product);

        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(string id, [FromBody]  EquipmentReferenceProcess product)
        {
            product.Id = new Guid(id);

            if (!EquipmentReferenceProcessDataRepository.Update(product))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

       [HttpDelete]
       [Route("{id}")]
        public IHttpActionResult Deletet(string id)
        {
            var serverData = EquipmentReferenceProcessDataRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            EquipmentReferenceProcessDataRepository.Delete(id);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

    }
}
