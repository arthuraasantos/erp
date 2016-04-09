using ERP.Services.PurchaseServices.Dtos.Stocks;
using ERP.Services.PurchaseServices.Interfaces.Base;

namespace ERP.Services.PurchaseServices.Interfaces.Products.Stocks
{
    public interface IStockService : IServiceOrganizationBase<StockDto,StockNewDto,StockEditDto>
    {

    }
}
