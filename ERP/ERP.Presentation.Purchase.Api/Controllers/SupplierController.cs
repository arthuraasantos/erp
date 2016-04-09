using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERP.Services.PurchaseServices.Dtos.Suppliers;
using ERP.Services.PurchaseServices.Interfaces.Suppliers;

namespace ERP.Presentation.Purchase.Api.Controllers
{
    public class SupplierController : ApiController
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/Supplier
        [Route("suppliers")]
        public IEnumerable<SupplierDto> Get()
        {
            var suppliers = _supplierService.GetAll();
            return suppliers;
        }

        // GET: api/Supplier/5
        public SupplierDto Get(Guid id, Guid organizationId)
        {
            var supplierDto = _supplierService.Get(id, organizationId);
            return supplierDto;
        }

        // POST: api/Supplier
        [HttpPost]
        [Route("suppliers")]
        public HttpResponseMessage Post([FromBody] SupplierNewDto newSupplier, Guid organizationId)
        {
            try
            {
                var result = _supplierService.Create(newSupplier, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, $"ID :{result}");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro na criação do fornecedor.");
            }
        }

        // PUT: api/Supplier/5
        public void Put(int id, [FromBody] SupplierEditDto supplierEditDto)
        {
            _supplierService.Update(supplierEditDto);
        }

        // DELETE: api/Supplier/5
        public void Delete(Guid id, Guid organizationId)
        {
            _supplierService.Delete(id, organizationId);
        }
    }
}
