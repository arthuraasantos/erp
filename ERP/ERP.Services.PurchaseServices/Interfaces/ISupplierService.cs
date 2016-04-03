using System;
using ERP.Services.PurchaseServices.Dtos.Supplier;

namespace ERP.Services.PurchaseServices.Interfaces
{
    public interface ISupplierService
    {
        Guid CreateSupplier(SupplierNewDto newSupplier, Guid organizationId);
    }
}
