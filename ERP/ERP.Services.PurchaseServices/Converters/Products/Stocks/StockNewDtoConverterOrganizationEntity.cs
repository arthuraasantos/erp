using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Services.PurchaseServices.Dtos.Stocks;

namespace ERP.Services.PurchaseServices.Converters.Products.Stocks
{
    public  class StockNewDtoConverterOrganizationEntity : IConverterOrganizationEntity<StockNewDto,Stock>
    {
        public Stock Convert(StockNewDto origin, Stock destiny)
        {
            if (destiny == null) destiny = new Stock();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;

            return destiny;
        }

        public StockNewDto Convert(Stock origin, StockNewDto destiny)
        {
            throw new ArgumentException("Método não deve ser utilizado!!");
        }
    }
}
