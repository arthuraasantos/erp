using ERP.Services.ShoppingAppService.Dtos.Common;

namespace ERP.Services.ShoppingAppService.Dtos.Supplier
{
    public class SupplierEditDto
    {
        public string Name { get; set; }
        public int CpfCnpj { get; set; }
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
    }
}
