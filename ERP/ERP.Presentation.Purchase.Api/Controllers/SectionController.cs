using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Services.PurchaseServices.Dtos.Sections;
using ERP.Services.PurchaseServices.Interfaces.Products.Sections;

namespace ERP.Presentation.Purchase.Api.Controllers
{
    public class SectionController : ApiController
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        // GET: api/Section
        [Route("sections")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Get(Guid organizationId)
        {
            //return _sectionService.GetAll(organizationId);
            return Request.CreateResponse(HttpStatusCode.Forbidden, "Método proibido");
        }

        [Route("sections")]
        public string Get(Guid id,Guid organizationId)
        {
            var section = _sectionService.Get(id, organizationId);
            return "value";
        }

        // POST: api/Section
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Section/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Section/5
        public void Delete(int id)
        {
        }
    }
}
