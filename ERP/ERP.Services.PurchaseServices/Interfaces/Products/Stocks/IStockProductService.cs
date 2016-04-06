using System;
using ERP.Services.PurchaseServices.Dtos.StockProducts;

namespace ERP.Services.PurchaseServices.Interfaces.Products.Stocks
{
    public interface IStockProductService 
    {
        Guid Create(StockProductNewDto newOrganization, Guid organizationId);
        StockProductDto Get(Guid id);
        void Delete(Guid id);
        void Update(StockProductEditDto editOrganizaztion);
    }
}
