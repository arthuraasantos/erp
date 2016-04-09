using System;
using ERP.Services.PurchaseServices.Dtos.PurchaseProducts;
using ERP.Services.PurchaseServices.Interfaces.Base;

namespace ERP.Services.PurchaseServices.Interfaces.Purchases
{
    public interface IPurchaseProductService : IServiceBase<PurchaseProductDto, PurchaseProductNewDto, PurchaseProductEditDto>
    {
    
    }
}
