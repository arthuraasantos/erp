using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Common;
using ERP.Domain.Entities.Configurations;
using ERP.Domain.Interfaces.Configurations;
using ERP.Infrastructure.Data.Context.Purchase;

namespace ERP.Infrastructure.Data.Repositories.Configurations
{
    public class ConfigurationRepository<T>: IConfigurationRepository
        where T: Configuration
    {
        protected PurchaseUnitOfWork Uow { get; set; }
        protected IDbConnection Dapper { get; set; }

        public ConfigurationRepository(IPurchaseUnitOfWork uow)
        {
            var unitOfWork = uow as PurchaseUnitOfWork;
            if (unitOfWork == null) throw new ArgumentException($"É obrigatório a utilização de uma unidade de trabalho do tipo {nameof(PurchaseUnitOfWork)}");

            Uow = unitOfWork;
            Dapper = unitOfWork.Database.Connection;
        }


        public Configuration Get(Guid organizationId, Guid configurationId)
            => Uow.Configurations.FirstOrDefault(c => c.OrganizationId == organizationId && c.Id == configurationId);

        public IEnumerable<Configuration> Get(Guid organizationId, ConfigurationType typeSearch)
            => Uow.Configurations.Where(c => c.OrganizationId == organizationId && c.ConfigurationType == typeSearch);


        public IEnumerable<Configuration> Get(Guid organizationId, string configurationName)
            => Uow.Configurations.Where(c => c.OrganizationId == organizationId && c.Name == configurationName);


        public Guid Set(Guid organizationId, Configuration newConfiguration)
        {
            var configurations = Uow.Configurations;
            Uow.Entry(newConfiguration).State = configurations.Any(c => c == newConfiguration)
                ? EntityState.Modified
                : EntityState.Added;
            Execute();

            return newConfiguration.Id;
        }

        public void Execute()
        {
            Uow.Commit();
        }
    }
}
