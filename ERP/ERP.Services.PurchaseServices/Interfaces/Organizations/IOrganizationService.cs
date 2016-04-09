using System;
using ERP.Services.PurchaseServices.Dtos.Organizations;

namespace ERP.Services.PurchaseServices.Interfaces.Organizations
{
    public interface IOrganizationService
    {
        Guid Create(OrganizationNewDto newPricePlan);
        OrganizationDto Get(Guid organizationId);
        void Delete(Guid organizationId);
        void Update(OrganizationEditDto editPricePlan);
    }
}
