using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Services.PurchaseServices.Dtos.Stocks;

namespace ERP.Services.PurchaseServices.Converters.Products.Stocks
{
    public class StockDtoConverterOrganizationEntity : IConverterOrganizationEntity<StockDto, Stock>
    {
        public Stock Convert(StockDto origin, Stock destiny)
        {
            if (destiny == null) destiny = new Stock();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            
            return destiny;
        }

        public StockDto Convert(Stock origin, StockDto destiny)
        {
            if (destiny == null) destiny = new StockDto();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;

            return destiny;
        }
    }
}
