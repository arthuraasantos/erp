using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ERP.Domain.Entities.Products;

namespace ERP.Infrastructure.Data.Mapping
{
    public class ProductDbMapping: EntityTypeConfiguration<Product>
    {
        public ProductDbMapping()
        {
            HasKey(p => p.Id);
            Property(p => p.Description)
                .HasColumnName("Description")
                .HasColumnAnnotation("Description", new IndexAnnotation(new IndexAttribute() { IsUnique = true}));
            Property(p => p.EanCode).HasColumnName("EanCode").HasMaxLength(20);
        }
    }
}
