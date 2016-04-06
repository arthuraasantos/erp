using System;
using ERP.Domain.Entities.Configurations;

namespace ERP.Services.PurchaseServices.Dtos.Configurations
{
    public class ConfigurationNewDto
    {
        public Guid ConfigurationId { get; set; }
        public Guid OrganizationId { get; set; }
        public ConfigurationType ConfigurationType { get; set; }
        public Guid OriginGuid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
