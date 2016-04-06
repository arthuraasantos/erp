using System;
using ERP.Services.PurchaseServices.Dtos.Stocks;

namespace ERP.Services.PurchaseServices.Interfaces.Products.Stocks
{
    public interface IStockService 
    {
        Guid Create(StockNewDto newOrganization, Guid organizationId);
        StockDto Get(Guid id);
        void Delete(Guid id);
        void Update(StockEditDto editOrganizaztion);
    }
}
