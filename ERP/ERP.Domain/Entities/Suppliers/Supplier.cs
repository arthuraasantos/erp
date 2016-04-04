using System.Collections.Generic;
using System.Net;
using ERP.Domain.Entities.Common;
using ERP.Domain.Entities.Organizations;
using ERP.Domain.Entities.Products;
using ERP.Domain.Services.Suppliers;

namespace ERP.Domain.Entities.Suppliers
{
    public class Supplier: AuditableOrganizationEntity
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string RegistrationName { get; set; }
        public string FantasyName { get; set; }
        public string Email { get; set; }
        public string ContactPeople { get; set; }
        public string Phone { get; set; }
        public string CityRegistration { get; set; }
        public string StateRegistration { get; set; }
        public string Comments { get; set; }
        public bool IsCompany { get; set; }

        public Address Address { get; set; }
        public Address FinancialAddress { get; set; }
        public virtual List<Product> Products { get; set; }

        public bool IsValid(Supplier entity) => SupplierService.IsValid(this);

        public bool IsActive() => SupplierService.IsActive(this);

        public bool CheckCompany() => CpfCnpj.ToString().Length > 11;
    }
}
