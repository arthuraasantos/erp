using ERP.Services.PurchaseServices.Dtos.Purchases;
using ERP.Services.PurchaseServices.Interfaces.Base;

namespace ERP.Services.PurchaseServices.Interfaces.Purchases
{
    public interface IPurchaseServiceOrganization : IServiceOrganizationBase<PurchaseDto, PurchaseNewDto, PurchaseEditDto>
    {
    
    }
}
