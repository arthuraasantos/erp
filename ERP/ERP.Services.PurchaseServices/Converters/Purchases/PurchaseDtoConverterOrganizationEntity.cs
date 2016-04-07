using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Purchases;
using ERP.Services.PurchaseServices.Converters.Purchases.PurchaseProducts;
using ERP.Services.PurchaseServices.Dtos.Purchases;

namespace ERP.Services.PurchaseServices.Converters.Purchases
{
    public class PurchaseDtoConverterOrganizationEntity : IConverterOrganizationEntity<PurchaseDto, Purchase>
    {
        private readonly PurchaseProductDtoConverterOrganizationEntity _converterChildProducts ;

        public PurchaseDtoConverterOrganizationEntity()
        {
            _converterChildProducts = new PurchaseProductDtoConverterOrganizationEntity();
        }

        public Purchase Convert(PurchaseDto origin, Purchase destiny)
        {
            if (destiny == null) destiny = new Purchase();

            destiny.OrganizationId = origin.OrganizationId;
            destiny.Id = origin.PurchaseId;
            destiny.InvoiceDate = origin.InvoiceDate;
            destiny.SupplierId = origin.SupplierId;
            destiny.StockId = origin.StockId;
            destiny.DeliveryValue = origin.DeliveryValue;
            destiny.ChildProducts = _converterChildProducts.Convert(origin.ChildProducts,null);
            destiny.Notes = origin.Notes;
            return destiny;
        }

        public PurchaseDto Convert(Purchase origin, PurchaseDto destiny)
        {
            if (destiny == null) destiny = new PurchaseDto();

            destiny.OrganizationId = origin.OrganizationId;
            destiny.PurchaseId = origin.Id;
            destiny.InvoiceDate = origin.InvoiceDate;
            destiny.SupplierId = origin.SupplierId;
            destiny.StockId = origin.StockId;
            destiny.DeliveryValue = origin.DeliveryValue;
            destiny.ChildProducts = _converterChildProducts.Convert(origin.ChildProducts, null);
            destiny.Notes = origin.Notes;
            return destiny;
        }
    }
}
