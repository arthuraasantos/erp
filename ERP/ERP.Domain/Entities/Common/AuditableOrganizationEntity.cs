using System;
using ERP.Domain.Entities.Organizations;

namespace ERP.Domain.Entities.Common
{
    public abstract class AuditableOrganizationEntity: AuditableBase
    {
        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
