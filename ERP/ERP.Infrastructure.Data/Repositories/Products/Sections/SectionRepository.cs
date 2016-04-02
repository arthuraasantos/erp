using ERP.Domain.Common;
using ERP.Domain.Entities.Products.Sections;
using ERP.Domain.Interfaces.Products.Sections;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Products.Sections
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(IPurchaseUnitOfWork uow) : base(uow)
        {
        }
    }
}
