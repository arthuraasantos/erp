using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Services.PurchaseServices.Dtos.Stocks;

namespace ERP.Services.PurchaseServices.Converters.Products.Stocks
{
    public class StockEditDtoConverterOrganizationEntity : IConverterOrganizationEntity<StockEditDto, Stock>
    {
        public Stock Convert(StockEditDto origin, Stock destiny)
        {
            if (destiny == null) destiny = new Stock();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;

            return destiny;
        }

        public StockEditDto Convert(Stock origin, StockEditDto destiny)
        {
            if (destiny == null) destiny = new StockEditDto();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;

            return destiny;
        }
    }
}
