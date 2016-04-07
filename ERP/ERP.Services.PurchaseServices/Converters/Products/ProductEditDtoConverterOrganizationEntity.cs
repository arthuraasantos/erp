using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products;
using ERP.Services.PurchaseServices.Dtos.Products;

namespace ERP.Services.PurchaseServices.Converters.Products
{
    public  class ProductEditDtoConverterOrganizationEntity : IConverterOrganizationEntity<ProductEditDto, Product>
    {
        public Product Convert(ProductEditDto origin, Product destiny)
        {
            if (destiny == null) destiny = new Product();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            destiny.EanCode = origin.EanCode;
            destiny.PricePlanId = origin.PricePlanId;
            destiny.SectionId = origin.SectionId;
            destiny.UniversalCodes = origin.UniversalCodes;

            return destiny;
        }

        public ProductEditDto Convert(Product origin, ProductEditDto destiny)
        {
            if (destiny == null) destiny = new ProductEditDto();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            destiny.EanCode = origin.EanCode;
            destiny.PricePlanId = origin.PricePlanId;
            destiny.SectionId = origin.SectionId;
            destiny.UniversalCodes = origin.UniversalCodes;

            return destiny;
        }
    }
}
