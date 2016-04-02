using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ERP.Domain.Common;
using ERP.Domain.Entities.Products;
using ERP.Domain.Entities.Suppliers;
using ERP.Infrastructure.Data.Mapping;

namespace ERP.Infrastructure.Data.Context.Purchase
{
    public class PurchaseUnitOfWork : DbContext, IPurchaseUnitOfWork
    {
        public Guid Id { get; }
        public IOrganization Organization { get; }
        public ILicence Licence { get; set; }
        public IUser User { get; set; }
        public IClient Client { get; set; }

        public PurchaseUnitOfWork()
            :base("DbErp")
        {
            Id = Guid.NewGuid();
            //User = user;
            //Licence = Licence;
            //Organization = organization;
            //Client = client;
        }
        
        #region Configurações
        
        public void Validate()
        {
            //ToDo: Implementar servidor de autenticação e autorização
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Remoção de convenções 

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            #endregion

            #region Configurações personalizadas do contexto

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            #endregion

            #region Mapeamento de tabelas do banco

            modelBuilder.Configurations.Add(new SupplierDbMapping());
            modelBuilder.Configurations.Add(new PricePlanDbMapping());
            modelBuilder.Configurations.Add(new ProductDbMapping());
            modelBuilder.Configurations.Add(new StockDbMapping());
            modelBuilder.Configurations.Add(new SectionDbMapping());

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDate") != null))
            {
                if (entry.State == EntityState.Added) entry.Property("CreateDate").CurrentValue = DateTime.UtcNow;
                if (entry.State == EntityState.Modified) entry.Property("CreateDate").IsModified = false;
            }
            return base.SaveChanges();
        }

        #endregion

        #region DBSets

        public DbSet<Supplier> Suppliers { get; set; } 
        public DbSet<Product> Products { get; set; } 
        #endregion
    }
}
