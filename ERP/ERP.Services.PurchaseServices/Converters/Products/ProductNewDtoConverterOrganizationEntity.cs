using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products;
using ERP.Services.PurchaseServices.Dtos.Products;

namespace ERP.Services.PurchaseServices.Converters.Products
{
    public class ProductNewDtoConverterOrganizationEntity : IConverterOrganizationEntity<ProductNewDto, Product>
    {
        public Product Convert(ProductNewDto origin, Product destiny)
        {
            if (destiny == null) destiny = new Product();
            destiny.Id = Guid.NewGuid();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            destiny.EanCode = origin.EanCode;
            destiny.PricePlanId = origin.PricePlanId;
            destiny.SectionId = origin.SectionId;

            return destiny;

        }

        public ProductNewDto Convert(Product origin, ProductNewDto destiny)
        {
            throw new ArgumentException("Método não deve ser utilizado!!");
        }
    }
}
