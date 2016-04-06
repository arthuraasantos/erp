using System;
using ERP.Services.PurchaseServices.Dtos.Purchases;

namespace ERP.Services.PurchaseServices.Interfaces.Purchases
{
    public interface IPurchaseService
    {
        Guid Create(PurchaseNewDto newOrganization, Guid organizationId);
        PurchaseDto Get(Guid id);
        void Delete(Guid id);
        void Update(PurchaseEditDto editOrganizaztion);
    }
}
