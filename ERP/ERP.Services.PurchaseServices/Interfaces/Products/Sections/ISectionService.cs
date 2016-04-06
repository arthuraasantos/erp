using System;
using ERP.Services.PurchaseServices.Dtos.Sections;

namespace ERP.Services.PurchaseServices.Interfaces.Products.Sections
{
    public interface ISectionService
    {
        Guid Create(SectionNewDto newOrganization, Guid organizationId);
        SectionDto Get(Guid id);
        void Delete(Guid id);
        void Update(SectionEditDto editOrganizaztion);
    }
}
