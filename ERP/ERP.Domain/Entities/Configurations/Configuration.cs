using System;
using System.ComponentModel;
using ERP.Domain.Entities.Organizations;

namespace ERP.Domain.Entities.Configurations
{
    public class Configuration
    {
        public Guid Id { get; set; }

        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }

        public ConfigurationType ConfigurationType { get; set; }
        public Guid OriginGuid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    //ToDo Verificar melhor local para ficar esse enum de configurações
    public enum ConfigurationType
    {
        [Description("Purchase")]
        Purchase,
        [Description("Sale")]
        Sales,
        [Description("Stock")]
        Stock,
        [Description("Financial")]
        Financial,
        [Description("Invoice")]
        Invoice,
        [Description("Product")]
        Product
    }


}

