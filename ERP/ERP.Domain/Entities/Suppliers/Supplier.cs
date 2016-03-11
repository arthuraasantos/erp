using ERP.Domain.Entities.Commom;
using ERP.Domain.Services.Suppliers;

namespace ERP.Domain.Entities.Suppliers
{
    public class Supplier: AuditableEntity
    {
        public string Name { get; set; }
        public int CpfCnpj { get; set; }
        public string RegistrationName { get; set; }
        public string FantasyName { get; set; }
        public string Email { get; set; }
        public virtual Address Address { get; set; }
        public virtual Address FinancialAddress { get; set; }
        public string ContactPeople { get; set; }
        public string Phone { get; set; }
        public string CityRegistration { get; set; }
        public string StateRegistration { get; set; }
        public string Comments { get; set; }

        public bool IsValid(Supplier entity) => SupplierService.IsValid(this);

        public bool IsActive() => SupplierService.IsActive(this);
    }
}
