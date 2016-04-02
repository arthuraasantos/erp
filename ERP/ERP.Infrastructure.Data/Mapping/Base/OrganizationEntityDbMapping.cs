using System.Data.Entity.ModelConfiguration;
using ERP.Domain.Entities.Common;

namespace ERP.Infrastructure.Data.Mapping.Base
{
    internal class OrganizationEntityDbMapping<T> : EntityTypeConfiguration<T>
        where T : AuditableOrganizationEntity
    {
        public OrganizationEntityDbMapping()
        {
            HasKey(p => p.Id);
            Property(p => p.CreateDate).IsRequired();
            Property(p => p.UpdateDate);
            Property(p => p.DeleteDate);
        }
    }
}
