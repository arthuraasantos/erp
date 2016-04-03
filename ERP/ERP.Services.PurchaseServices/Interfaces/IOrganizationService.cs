using System;
using ERP.Services.PurchaseServices.Dtos.Organization;

namespace ERP.Services.PurchaseServices.Interfaces
{
    public interface IOrganizationService
    {
        Guid Create(OrganizationNewDto organization);
        void Update(OrganizationEditDto organization);
        OrganizationDto Get(Guid organizationId);
        void Delete(Guid organizationId);
    }
}
