using System.Data.Entity.ModelConfiguration;
using ERP.Domain.Entities.Common;

namespace ERP.Infrastructure.Data.Mapping.Base
{
    internal abstract class BaseDbMapping<T>: EntityTypeConfiguration<T>
        where T : AuditableBase
    {
        protected BaseDbMapping()
        {
            HasKey(p => p.Id);
            Property(p => p.CreateDate).IsRequired();
            Property(p => p.UpdateDate);
            Property(p => p.DeleteDate);
        }
    }
}
