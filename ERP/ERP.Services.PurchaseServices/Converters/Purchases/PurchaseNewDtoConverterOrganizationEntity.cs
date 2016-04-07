using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Purchases;
using ERP.Services.PurchaseServices.Converters.Purchases.PurchaseProducts;
using ERP.Services.PurchaseServices.Dtos.Purchases;

namespace ERP.Services.PurchaseServices.Converters.Purchases
{
    public class PurchaseNewDtoConverterOrganizationEntity : IConverterOrganizationEntity<PurchaseNewDto, Purchase>
    {
        private readonly PurchaseProductDtoConverterOrganizationEntity _converterChildProducts ;

        public PurchaseNewDtoConverterOrganizationEntity()
        {
            _converterChildProducts = new PurchaseProductDtoConverterOrganizationEntity();
        }


        public Purchase Convert(PurchaseNewDto origin, Purchase destiny)
        {
            if (destiny == null) destiny = new Purchase();

            destiny.OrganizationId = origin.OrganizationId;
            destiny.InvoiceDate = origin.InvoiceDate;
            destiny.SupplierId = origin.SupplierId;
            destiny.StockId = origin.StockId;
            destiny.DeliveryValue = origin.DeliveryValue;
            destiny.ChildProducts = _converterChildProducts.Convert(origin.ChildProducts, null);
            destiny.Notes = origin.Notes;
            return destiny;
        }

        public PurchaseNewDto Convert(Purchase origin, PurchaseNewDto destiny)
        {
            throw new NotImplementedException();
        }
    }
}
