using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Services.PurchaseServices.Dtos.Supplier;

namespace ERP.Services.PurchaseServices.Interfaces
{
    public interface ISupplierAppService
    {
        Guid CreateSupplier(SupplierNewDto newSupplier);
    }
}
