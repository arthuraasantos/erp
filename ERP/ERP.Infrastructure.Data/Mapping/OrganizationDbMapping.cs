using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities.Organizations;
using ERP.Infrastructure.Data.Mapping.Base;

namespace ERP.Infrastructure.Data.Mapping
{
    internal class OrganizationDbMapping: BaseDbMapping<Organization>
    {
        public OrganizationDbMapping()
        {
            Property(p => p.Id).HasColumnName("OrganizationId");
            Property(p => p.Name).HasColumnName("Name");
            Property(p => p.Email).HasColumnName("Email");
            Property(p => p.RegistrationCode).HasColumnName("RegistrationCode");
            Property(p => p.RegistrationName).HasColumnName("RegistrationName");

            ToTable("Organizations");
        }
    }
}
