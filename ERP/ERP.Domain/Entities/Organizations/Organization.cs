using ERP.Domain.Entities.Common;

namespace ERP.Domain.Entities.Organizations
{
    public class Organization: AuditableBase
    {
        public string Name { get; set; }
        public string RegistrationName { get; set; } // Razão Social
        public string Email { get; set; }
        public int RegistrationCode { get; set; } // CpfCnpj
        public Address Address { get; set; }
    }
}
