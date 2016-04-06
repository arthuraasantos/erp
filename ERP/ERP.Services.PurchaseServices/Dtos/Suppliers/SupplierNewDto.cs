using System;

namespace ERP.Services.PurchaseServices.Dtos.Suppliers
{
    public class SupplierNewDto
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
