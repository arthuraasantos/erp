using System;
using System.Data.Common;
using System.Data.Entity;
using ERP.Domain.Common;
using ERP.Infrastructure.Data.EntityFramework;
using ERP.Infrastructure.Data.Mapping;

namespace ERP.Infrastructure.Data.Context.Shopping
{
    public class PurchaseUnitOfWork : ErpUnitOfWork, IErpContext
    {
        public Guid Id { get; }
        public IOrganization Organization { get; }
        public ILicence Licence { get; set; }
        public IUser User { get; set; }
        public IClient Client { get; set; }

        public PurchaseUnitOfWork(IUser user, IOrganization organization, IClient client, DbConnection conn, IErpContext context)
            : base(conn,context)
        {
            Id = Guid.NewGuid();
            User = user;
            //Licence = Licence;
            Organization = organization;
            Client = client;
        }

        /// <summary>
        /// Valida contexto com licença + usuário + autorização
        /// </summary>
        public void Validate()
        {
            //ToDo: Implementar servidor de autenticação e autorização
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SupplierDbMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
