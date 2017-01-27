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
    [RoutePrefix("api/referenceprocess")]
    public class ReferenceProcessController : ApiController
    {
        static readonly IReferenceProcessRepository ReferenceProcesDataRepository = new ReferenceProcessRepository();
        [ActionName("GetAll")]
        [Route("", Name = "GetReferenceProcessAll")]
        public IHttpActionResult GetEquipments()
        {
            IEnumerable<ReferenceProcess> data = ReferenceProcesDataRepository.GetAll();
            return Ok(data);
        }

        [ActionName("GetByGuid")]
        [Route("{id}", Name = "GetReferenceProcessByGuid")]
        public IHttpActionResult GetServerDataById(string id)
        {
            var equipment = ReferenceProcesDataRepository.GetByGuid(new Guid(id));

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }
    }
}
