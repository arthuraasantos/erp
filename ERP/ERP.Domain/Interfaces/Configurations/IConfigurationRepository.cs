using System;
using System.Collections.Generic;
using ERP.Domain.Entities.Configurations;

namespace ERP.Domain.Interfaces.Configurations
{
    public interface IConfigurationRepository
    {
        Configuration Get(Guid organizationId, Guid configurationId);
        IEnumerable<Configuration> Get(Guid organizationId, ConfigurationType typeSearch);
        IEnumerable<Configuration> Get(Guid organizationId, string configurationName);
        Guid Set(Guid organizationId, Configuration configuration);
    }
}
