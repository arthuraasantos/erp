using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Services.PurchaseServices.Dtos.Stocks;
using ERP.Services.PurchaseServices.Interfaces.Products.Stocks;

namespace ERP.Presentation.Purchase.Api.Controllers
{
    public class StockController : ApiController
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        // GET: api/Stock
        [Route("stocks")]
        [ResponseType(typeof(StockDto))]
        public HttpResponseMessage Get(Guid stockId, Guid organizationId)
        {
            try
            {
                var stockDto = _stockService.Get(stockId, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, stockDto);
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

        [Route("stocks")]
        [ResponseType(typeof(Guid))]
        public HttpResponseMessage Post([FromBody]StockNewDto stockNewDto)
        {
            try
            {
                var stockId = _stockService.Create(stockNewDto, stockNewDto.OrganizationId);
                return Request.CreateResponse(HttpStatusCode.OK, stockId);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("stocks")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Put([FromBody]StockEditDto stockEditDto)
        {
            try
            {
                _stockService.Update(stockEditDto);
                return Request.CreateResponse(HttpStatusCode.OK, "Sua alteração foi feita");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema nessa alteração. Erro: {ex.Message}");
            }
        }

        [Route("stocks")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Delete([FromUri]Guid stockId, [FromUri] Guid organizationId)
        {
            try
            {
                _stockService.Delete(stockId, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, "Estoque deletado");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema ao deletar. Erro: {ex.Message}");
            }
        }
    }
}
