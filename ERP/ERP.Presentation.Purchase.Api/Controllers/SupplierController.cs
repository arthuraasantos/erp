using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERP.Services.PurchaseServices.Dtos.Supplier;
using ERP.Services.PurchaseServices.Interfaces;

namespace ERP.Presentation.Purchase.Api.Controllers
{
    public class SupplierController : ApiController
    {
        private readonly ISupplierAppService _supplierService;
        public SupplierController(ISupplierAppService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/Supplier
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Supplier/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Supplier
        [HttpPost]
        [Route("suppliers")]
        public HttpResponseMessage Post([FromBody] SupplierNewDto newSupplier, Guid organizationId) 
        {
            try
            {
                var result = _supplierService.CreateSupplier(newSupplier, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, $"ID :{result}");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro na criação do fornecedor.");
            }
        }

        // PUT: api/Supplier/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Supplier/5
        public void Delete(int id)
        {
        }
    }
}
