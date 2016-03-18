﻿using System;

namespace ERP.Domain.Entities.Common
{
    public abstract class AuditableOrganizationEntity
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
