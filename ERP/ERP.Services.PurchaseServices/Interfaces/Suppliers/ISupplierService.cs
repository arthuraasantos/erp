using System.Collections.Generic;
using ERP.Services.PurchaseServices.Dtos.Suppliers;
using ERP.Services.PurchaseServices.Interfaces.Base;

namespace ERP.Services.PurchaseServices.Interfaces.Suppliers
{
    public interface ISupplierService : IServiceOrganizationBase<SupplierDto, SupplierNewDto, SupplierEditDto>
    {
        IEnumerable<SupplierDto> GetAll();
    }
}
