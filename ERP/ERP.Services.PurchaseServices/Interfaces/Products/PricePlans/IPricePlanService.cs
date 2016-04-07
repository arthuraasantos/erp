using System;
using ERP.Services.PurchaseServices.Dtos.PricePlans;

namespace ERP.Services.PurchaseServices.Interfaces.Products.PricePlans
{
    public interface IPricePlanService
    {
        Guid Create(PricePlanNewDto newPricePlan, Guid organizationId);
        PricePlanDto Get(Guid id);
        void Delete(Guid id);
        void Update(PricePlanEditDto editPricePlan);
    }
}
