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
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/Supplier
        public IEnumerable<SupplierDto> Get()
        {
            var suppliers = _supplierService.GetAll();
            return suppliers;
        }

        // GET: api/Supplier/5
        public SupplierDto Get(Guid id)
        {
            var supplierDto = _supplierService.GetById(id);
            return supplierDto;
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
        public void Put(int id, [FromBody] SupplierEditDto supplierEditDto)
        {
            _supplierService.Update(supplierEditDto);
        }

        // DELETE: api/Supplier/5
        public void Delete(Guid id)
        {
            _supplierService.Delete(id);
        }
    }
}
