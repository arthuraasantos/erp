using System;
using ERP.Services.PurchaseServices.Dtos.Products;

namespace ERP.Services.PurchaseServices.Interfaces.Products
{
    public interface IProductService 
    {
        Guid Create(ProductNewDto newOrganization, Guid organizationId);
        ProductDto Get(Guid id);
        void Delete(Guid id);
        void Update(ProductEditDto editOrganizaztion);
    }
}
