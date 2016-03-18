using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ERP.Domain.Entities.Suppliers;

namespace ERP.Infrastructure.Data.Mapping
{
    public class SupplierDbMapping: EntityTypeConfiguration<Supplier>
    {
        public SupplierDbMapping()
        {
            ToTable("Suppliers");

            HasKey(s => s.Id);
            HasRequired(s => s.Organization);

            Property(s => s.Name).HasColumnName("Name").HasMaxLength(100);
            Property(s => s.CpfCnpj)
                .HasColumnAnnotation("IndexCpfCnpj", new IndexAnnotation(new IndexAttribute() {IsUnique = true}));
            
            Ignore(p => p.Address);
            Ignore(p => p.FinancialAddress);

            
        }
    }
}
