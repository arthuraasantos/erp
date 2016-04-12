using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Services.PurchaseServices.Dtos.PricePlans;
using ERP.Services.PurchaseServices.Interfaces.Products.PricePlans;

namespace ERP.Presentation.Purchase.Api.Controllers
{
    public class PricePlanController : ApiController
    {
        private readonly IPricePlanService _pricePlanService;

        public PricePlanController(IPricePlanService pricePlanService)
        {
            _pricePlanService = pricePlanService;
        }

        // GET: api/PricePlan
        [Route("priceplans")]
        [ResponseType(typeof(PricePlanDto))]
        public HttpResponseMessage Get(Guid id, Guid organizationId)
        {
            try
            {
                var pricePlanDto = _pricePlanService.Get(id, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, pricePlanDto);
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

        [Route("priceplans")]
        [HttpPost]
        [ResponseType(typeof(Guid))]
        public HttpResponseMessage Post([FromBody]PricePlanNewDto pricePlanNewDto)
        {
            try
            {
                var pricePlanId = _pricePlanService.Create(pricePlanNewDto, pricePlanNewDto.OrganizationId);
                return Request.CreateResponse(HttpStatusCode.OK, pricePlanId);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("priceplans")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Put([FromBody]PricePlanEditDto pricePlanEditDto)
        {
            try
            {
                _pricePlanService.Update(pricePlanEditDto);
                return Request.CreateResponse(HttpStatusCode.OK, "Sua alteração foi feita");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema nessa alteração. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("priceplans")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Delete([FromUri] Guid pricePlanId,[FromUri] Guid organizationId)
        {
            try
            {
                _pricePlanService.Delete(pricePlanId, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, "Plano de preços deletado");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema ao deletar. Erro: {ex.Message}");
            }
        }
    }
}
