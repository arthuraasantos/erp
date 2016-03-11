using System;
using System.Data.Common;
using ERP.Crosscut.UnitOfWork;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ERP.Domain.Common;

namespace ERP.Infrastructure.Data.EntityFramework
{
    public class ErpUnitOfWork : DbContext, IUnitOfWork
    {
        private IErpContext ErpContext { get; }

        
        public ErpUnitOfWork(DbConnection conn, IErpContext context)
            :base(conn,false)
        {
            ErpContext = context;
            Configure();
        }

        #region Configurações

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }

        private void Configure()
        {
            // ToDo Configurações padrão do contexto
            throw new NotImplementedException();
        }

        #endregion


        public void Commit() => SaveChanges();
    }
}
