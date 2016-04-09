using System;

namespace ERP.Services.PurchaseServices.Interfaces.Base
{
    public interface IServiceBase<TDto, TNewDto, TEditDto>
        where TDto : class
        where TNewDto : class
        where TEditDto : class
    {
        Guid Create(TNewDto newPricePlan, Guid organizationId);
        TDto Get(Guid id);
        void Delete(Guid id);
        void Update(TEditDto editPricePlan);
    }
}
