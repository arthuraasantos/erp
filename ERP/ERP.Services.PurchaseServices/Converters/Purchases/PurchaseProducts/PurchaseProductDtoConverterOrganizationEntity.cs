using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Purchases;
using ERP.Services.PurchaseServices.Dtos.PurchaseProducts;

namespace ERP.Services.PurchaseServices.Converters.Purchases.PurchaseProducts
{
    public class PurchaseProductDtoConverterOrganizationEntity : IConverterOrganizationEntity<PurchaseProductDto, PurchaseProduct>
    {
        public PurchaseProduct Convert(PurchaseProductDto origin, PurchaseProduct destiny)
        {
            if (destiny == null) destiny = new PurchaseProduct();

            destiny.PurcharseId = origin.PurcharseId;
            destiny.Id = origin.PurchaseProductId;
            destiny.Quantity = origin.Quantity;
            destiny.Value = origin.Value;

            return destiny;
        }

        public PurchaseProductDto Convert(PurchaseProduct origin, PurchaseProductDto destiny)
        {
            if (destiny == null) destiny = new PurchaseProductDto();

            destiny.PurcharseId = origin.PurcharseId;
            destiny.PurchaseProductId = origin.Id;
            destiny.Quantity = origin.Quantity;
            destiny.Value = origin.Value;

            return destiny;
        }

        public List<PurchaseProductDto> Convert(List<PurchaseProduct> origin, List<PurchaseProductDto> destiny)
        {
            if (destiny == null) destiny = new List<PurchaseProductDto>();
            destiny.AddRange(origin.Select(item => Convert(item, null)));

            return destiny;
        }

        public List<PurchaseProduct> Convert(List<PurchaseProductDto> origin, List<PurchaseProduct> destiny)
        {
            if (destiny == null) destiny = new List<PurchaseProduct>();
            destiny.AddRange(origin.Select(item => Convert(item, null)));

            return destiny;
        }
    }
}
