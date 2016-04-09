using ERP.Domain.Common;
using ERP.Domain.Entities.Products.PricePlans;
using ERP.Domain.Interfaces.Products.PricePlans;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Products.PricePlans
{
    public class PricePlanRepository : RepositoryOrganizationBase<PricePlan>, IPricePlanRepository
    {
        public PricePlanRepository(IPurchaseUnitOfWork uow) : base(uow)
        {
        }
    }
}
