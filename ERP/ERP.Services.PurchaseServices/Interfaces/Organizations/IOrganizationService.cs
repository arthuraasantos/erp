using System;
using ERP.Services.PurchaseServices.Dtos.Organizations;

namespace ERP.Services.PurchaseServices.Interfaces.Organizations
{
    public interface IOrganizationService 
    {
        Guid Create(OrganizationNewDto newOrganization);
        OrganizationDto Get(Guid id);
        void Delete(Guid id);
        void Update(OrganizationEditDto editOrganizaztion);
    }
}
