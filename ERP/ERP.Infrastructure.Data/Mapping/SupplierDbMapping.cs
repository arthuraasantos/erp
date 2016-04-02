using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using ERP.Domain.Entities.Suppliers;
using ERP.Infrastructure.Data.Mapping.Base;

namespace ERP.Infrastructure.Data.Mapping
{
    internal class SupplierDbMapping: OrganizationEntityDbMapping<Supplier>
    {
        public SupplierDbMapping()
        {
            Property(p => p.Id).HasColumnName("SupplierId");
            Property(s => s.Name).HasColumnName("Name").HasMaxLength(100);
            Property(s => s.CpfCnpj)
                .HasColumnAnnotation("IndexCpfCnpj", new IndexAnnotation(new IndexAttribute() {IsUnique = true}));
            
            Ignore(p => p.Address);
            Ignore(p => p.FinancialAddress);

            ToTable("Suppliers");

        }
    }
}
