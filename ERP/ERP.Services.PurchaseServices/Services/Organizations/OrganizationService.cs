using System;
using ERP.Domain.Interfaces.Organizations;
using ERP.Services.PurchaseServices.Converters.Organizations;
using ERP.Services.PurchaseServices.Dtos.Organizations;
using ERP.Services.PurchaseServices.Interfaces.Organizations;

namespace ERP.Services.PurchaseServices.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ConverterOrganizationNewDtoToDomain _converterNewDto;

        public OrganizationService(IOrganizationRepository organizationRepository, ConverterOrganizationNewDtoToDomain converterNewDto)
        {
            _organizationRepository = organizationRepository;
            _converterNewDto = converterNewDto;
        }

        private static bool Isvalid(OrganizationNewDto organization) => !string.IsNullOrWhiteSpace(organization.Name);

        private static bool Isvalid(OrganizationDto organization) => !string.IsNullOrWhiteSpace(organization.Name);

        private bool Isvalid(OrganizationEditDto organization)
        {
            //ToDo Não implementei ,porque ainda não sei qual informação vamos considerar como obrigatória.
            throw new NotImplementedException("Não implementado ainda");
        }

        public Guid Create(OrganizationNewDto organization)
        {
            if (!Isvalid(organization)) throw new ArgumentNullException($"Campo obrigatório não foi preenchido");
            var newOrganization = _converterNewDto.Convert(organization, null);
            _organizationRepository.Save(newOrganization);

            return newOrganization.Id;
        }

        public void Update(OrganizationEditDto organization)
        {
            //if (!Isvalid(organization)) throw new ArgumentNullException($"Campo obrigatório não foi preenchido");
            //var editOrganization = 
                
        }

        public OrganizationDto Get(Guid organizationId)
        {
        //    var organization =_organizationRepository.Get(organizationId);
        //    var organizationDto = _converterNewDto.Convert(organization, null);
        //    return organization;
        OrganizationDto organization = new OrganizationDto();
        return organization;
    }

        public void Delete(Guid organizationId)
        {
            throw new NotImplementedException();
        }

    }
}
