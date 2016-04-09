using ERP.Services.PurchaseServices.Dtos.Products;
using ERP.Services.PurchaseServices.Interfaces.Base;

namespace ERP.Services.PurchaseServices.Interfaces.Products
{
    public interface IProductService  : IServiceOrganizationBase<ProductDto, ProductNewDto, ProductEditDto>
    {
        
    }
}
