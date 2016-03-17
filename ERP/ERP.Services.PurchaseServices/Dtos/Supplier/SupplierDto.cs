using ERP.Services.PurchaseServices.Dtos.Common;

namespace ERP.Services.PurchaseServices.Dtos.Supplier
{
    public class SupplierDto
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string RegistrationName { get; set; }
        public string FantasyName { get; set; }
        public string Email { get; set; }
        public virtual AddressDto Address { get; set; }
        public virtual AddressDto FinancialAddress { get; set; }
        public string ContactPeople { get; set; }
        public string Phone { get; set; }
        public string CityRegistration { get; set; }
        public string StateRegistration { get; set; }
        public string Comments { get; set; }
        public bool IsCompany { get; set; }
    }
}
