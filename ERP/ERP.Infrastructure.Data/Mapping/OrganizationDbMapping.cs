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
            Property(p => p.Address.AddressLine).HasColumnName("AddressLine");
            Property(p => p.Address.Number).HasColumnName("Number");
            Property(p => p.Address.Adjunct).HasColumnName("Adjunct");
            Property(p => p.Address.District).HasColumnName("District");
            Property(p => p.Address.ZipCode).HasColumnName("ZipCode");
            Property(p => p.Address.City).HasColumnName("City");
            Property(p => p.Address.State).HasColumnName("State");

            ToTable("Organizations");
        }
    }
}
