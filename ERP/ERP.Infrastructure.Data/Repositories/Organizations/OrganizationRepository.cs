using ERP.Domain.Common;
using ERP.Domain.Entities.Organizations;
using ERP.Domain.Interfaces.Organizations;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Organizations
{
    public class OrganizationRepository : RepositoryBase<Organization> , IOrganizationRepository
    {
        public OrganizationRepository(IPurchaseUnitOfWork uow) : base(uow)
        {
        }
    }
}
