using System;
using ERP.Services.PurchaseServices.Dtos.Supplier;

namespace ERP.Services.PurchaseServices.Interfaces
{
    public interface ISupplierAppService
    {
        Guid CreateSupplier(SupplierNewDto newSupplier, Guid organizationId);
    }
}
