using System;
using ERP.Services.PurchaseServices.Dtos.PurchaseProducts;

namespace ERP.Services.PurchaseServices.Interfaces.Purchases
{
    public interface IPurchaseProductService
    {
        Guid Create(PurchaseProductNewDto newOrganization, Guid organizationId);
        PurchaseProductDto Get(Guid id);
        void Delete(Guid id);
        void Update(PurchaseProductEditDto editOrganizaztion);
    }
}
