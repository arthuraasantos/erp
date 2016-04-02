using ERP.Domain.Entities.Common;

namespace ERP.Infrastructure.Data.Mapping.Base
{
    internal class OrganizationEntityDbMapping<T> : BaseDbMapping<T>
        where T : AuditableOrganizationEntity
    {
        public OrganizationEntityDbMapping()
        {
            HasKey(p => p.Id);
            Property(p => p.OrganizationId).IsRequired();
            HasRequired(p => p.Organization).WithMany().HasForeignKey(x => x.OrganizationId);
            Property(p => p.CreateDate).IsRequired();
            Property(p => p.UpdateDate);
            Property(p => p.DeleteDate);
        }
    }
}
