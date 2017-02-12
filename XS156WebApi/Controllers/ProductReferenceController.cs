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
    [RoutePrefix("api/products")]
    public class ProductReferenceController : ApiController
    {
        private static readonly IProductReferenceRepository ProductReferenceDataRepository = new ProductReferenceRepository();
       
        [ ActionName("GetAll")]
        [Route("", Name = "GetProductAll")]
        public IHttpActionResult Get()
        {
            IEnumerable<ProductReference> data = ProductReferenceDataRepository.GetAll();
             return Ok(data);
        }


        [ActionName("GetByGuid")]
        [Route("{id}", Name = "GetProductByGuid")]
        public IHttpActionResult Get(string id)
        {
            var equipment = ProductReferenceDataRepository.Get(id);

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        [ActionName("GetProductByName")]
        [Route("GetProductByName/{reference}", Name = "GetProductByName")]
        public IHttpActionResult GetProductByName(string reference)
        {
            reference = reference.ToUpper();
            ProductReference data = ProductReferenceDataRepository.GetByName(reference);
            return Ok(data);
        }

        [HttpPost]
        [ActionName("Add")]
        [Route("")]
        public IHttpActionResult Post([FromBody] ProductReference product)
        {
            if (product == null)
            {
                return BadRequest("Equipment cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product = ProductReferenceDataRepository.Add(product);

            return CreatedAtRoute("GetProductByGuid", new { id = product.Id }, product);

        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(string id, [FromBody] ProductReference product)
        {
            product.Id = new Guid(id);

            if (!ProductReferenceDataRepository.Update(product))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

       [HttpDelete]
       [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            var serverData = ProductReferenceDataRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            ProductReferenceDataRepository.Delete(serverData);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

    }
}
