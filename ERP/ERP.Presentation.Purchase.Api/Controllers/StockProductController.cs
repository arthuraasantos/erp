using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Services.PurchaseServices.Dtos.Sections;
using ERP.Services.PurchaseServices.Dtos.StockProducts;
using ERP.Services.PurchaseServices.Interfaces.Products.Stocks;

namespace ERP.Presentation.Purchase.Api.Controllers
{
    public class StockProductController : ApiController
    {
        private readonly IStockProductService _stockProductService;

        public StockProductController(IStockProductService stockProductService)
        {
            _stockProductService = stockProductService;
        }

        [Route("stockproducts")]
        [ResponseType(typeof(StockProductDto))]
        public HttpResponseMessage Get(Guid stockProductId, Guid organizationId)
        {
            try
            {
                var stockProductDto = _stockProductService.Get(stockProductId, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, stockProductDto);
            }
            catch (NullReferenceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("stockproducts")]
        [ResponseType(typeof(Guid))]
        public HttpResponseMessage Post([FromBody]StockProductNewDto stockProductNewDto)
        {
            try
            {
                var stockProductId = _stockProductService.Create(stockProductNewDto, stockProductNewDto.OrganizationId);
                return Request.CreateResponse(HttpStatusCode.OK, stockProductId);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("stockproducts")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Put([FromBody]StockProductEditDto stockProductEditDto)
        {
            try
            {
                _stockProductService.Update(stockProductEditDto);
                return Request.CreateResponse(HttpStatusCode.OK, "Sua alteração foi feita");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema nessa alteração. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("stockproducts")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Delete([FromUri]Guid organizationId, [FromUri]Guid stockProductId)
        {
            try
            {
                _stockProductService.Delete(stockProductId, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, "Produto estoque deletado");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema ao deletar. Erro: {ex.Message}");
            }
        }
    }
}
