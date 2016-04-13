using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Services.PurchaseServices.Dtos.Products;
using ERP.Services.PurchaseServices.Interfaces.Products;

namespace ERP.Presentation.Purchase.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products")]
        [ResponseType(typeof(ProductDto))]
        public HttpResponseMessage Get(Guid productId, Guid organizationId)
        {
            try
            {
                var productDto = _productService.Get(productId, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, productDto);
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

       [HttpPost]
       [Route("products")]
       [ResponseType(typeof(Guid))]
        public HttpResponseMessage Post([FromBody]ProductNewDto productNewDto)
        {
            try
            {
                var productId = _productService.Create(productNewDto, productNewDto.OrganizationId);
                return Request.CreateResponse(HttpStatusCode.OK, productId);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("products")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Put([FromBody]ProductEditDto productEditDto)
        {
            try
            {
                _productService.Update(productEditDto);
                return Request.CreateResponse(HttpStatusCode.OK, "Sua alteração foi feita");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema nessa alteração. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("products")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Delete([FromUri] Guid productId, [FromUri] Guid organizationId)
        {
            try
            {
                _productService.Delete(productId, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, "Produto deletado");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema ao deletar. Erro: {ex.Message}");
            }
        }
    }
}
