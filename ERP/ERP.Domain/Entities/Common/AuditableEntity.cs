using System;

namespace ERP.Domain.Entities.Commom
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
