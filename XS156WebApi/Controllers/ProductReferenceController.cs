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
        private IProductReferenceRepository _productReferenceDataRepository;

        public ProductReferenceController(IProductReferenceRepository productReferenceDataRepository)
        {
            _productReferenceDataRepository = productReferenceDataRepository;
        }


        [ ActionName("GetAll")]
        [Route("", Name = "GetProductAll")]
        public IHttpActionResult Get()
        {
            IEnumerable<ProductReference> data = _productReferenceDataRepository.GetAll();
             return Ok(data);
        }


        [ActionName("GetByGuid")]
        [Route("{id}", Name = "GetProductByGuid")]
        public IHttpActionResult Get(string id)
        {
            var equipment = _productReferenceDataRepository.Get(id);

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        [ActionName("GetProductByName")]
        [Route("GetProductByName/{reference}", Name = "GetProductByName")]
        public IHttpActionResult GetProductByName(string reference)
        {
            reference = reference.ToUpper();
            ProductReference data = _productReferenceDataRepository.GetByName(reference);
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
            product = _productReferenceDataRepository.Add(product);

            return CreatedAtRoute("GetProductByGuid", new { id = product.Id }, product);

        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(string id, [FromBody] ProductReference product)
        {
            product.Id = new Guid(id);

            if (!_productReferenceDataRepository.Update(product))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

       [HttpDelete]
       [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            var serverData = _productReferenceDataRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _productReferenceDataRepository.Delete(serverData);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

    }
}
