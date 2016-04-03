using System;
using ERP.Services.PurchaseServices.Dtos.Common;

namespace ERP.Services.PurchaseServices.Dtos.Organization
{
    public class OrganizationEditDto
    {
        public Guid OrganizationId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string RegistrationName { get; set; }
        public string Email { get; set; }
        public int RegistrationCode { get; set; }
        public AddressDto Address { get; set; }
    }
}
