using System.Data.Entity.ModelConfiguration;
using ERP.Domain.Entities;
using ERP.Domain.Entities.Suppliers;

namespace ERP.Infrastructure.Data.Mapping
{
    public class SupplierDbMapping: EntityTypeConfiguration<Supplier>
    {
        public SupplierDbMapping()
        {
            HasKey(s => s.Id);
            Property(s => s.Name).HasColumnName("Name").HasMaxLength(100);

            ToTable("Suppliers");
        }
    }
}
