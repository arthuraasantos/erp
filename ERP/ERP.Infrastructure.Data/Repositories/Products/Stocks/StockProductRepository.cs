using ERP.Domain.Common;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Domain.Interfaces.Products.Stocks;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Products.Stocks
{
    public class StockProductRepository : RepositoryBase<StockProduct>, IStockProductRepository
    {
        public StockProductRepository(IPurchaseUnitOfWork uow) : base(uow)
        {
        }
    }
}
