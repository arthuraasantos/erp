using System;
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

        [Route("sections")]
        [ResponseType(typeof(SectionDto))]
        public HttpResponseMessage Get(Guid id,Guid organizationId)
        {
            try
            {
                var section = _sectionService.Get(id, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, section);
            }
            catch(NullReferenceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [Route("sections")]
        [ResponseType(typeof(Guid))]
        public HttpResponseMessage Post([FromBody]SectionNewDto section)
        {
            try
            {
                var sectionId = _sectionService.Create(section, section.OrganizationId);
                return Request.CreateResponse(HttpStatusCode.OK, sectionId);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("sections")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Put([FromBody]SectionEditDto section)
        {
            try
            {
                _sectionService.Update(section);
                return Request.CreateResponse(HttpStatusCode.OK, "Sua alteração foi feita");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema nessa alteração. Erro: {ex.Message}");
            }
            

        }

        [HttpDelete]
        [Route("sections")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Delete([FromUri]Guid organizationId,[FromUri]Guid sectionId)
        {
            try
            {
                _sectionService.Delete(sectionId, organizationId);
                return Request.CreateResponse(HttpStatusCode.OK, "Seção deletada");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"Opa, ocorreu algum problema ao deletar. Erro: {ex.Message}");
            }
        }
    }
}
