using System;

namespace ERP.Services.PurchaseServices.Interfaces.Base
{
    public interface IServiceOrganizationBase<TDto, TNewDto, TEditDto>
        where TDto : class
        where TNewDto : class
        where TEditDto : class
    {
        Guid Create(TNewDto newPricePlan, Guid organizationId);
        TDto Get(Guid id, Guid organizationId);
        void Delete(Guid id, Guid organizationId);
        void Update(TEditDto editPricePlan);
    }
}
