using ERP.Services.PurchaseServices.Dtos.StockProducts;
using ERP.Services.PurchaseServices.Interfaces.Base;

namespace ERP.Services.PurchaseServices.Interfaces.Products.Stocks
{
    public interface IStockProductService : IServiceOrganizationBase<StockProductDto,StockProductNewDto,StockProductEditDto>
    {

    }
}
