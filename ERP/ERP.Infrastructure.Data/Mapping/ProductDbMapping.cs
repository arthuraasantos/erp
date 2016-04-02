using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using ERP.Domain.Entities.Products;
using ERP.Infrastructure.Data.Mapping.Base;

namespace ERP.Infrastructure.Data.Mapping
{
    internal class ProductDbMapping: OrganizationEntityDbMapping<Product>
    {
        public ProductDbMapping()
        {
            HasKey(p => p.Id);
            HasOptional(p => p.Section).WithMany().HasForeignKey(p => p.SectionId);
            HasOptional(p => p.PricePlan).WithMany().HasForeignKey(p => p.PricePlanId);
            Property(p => p.Id).HasColumnName("ProductId");
            Property(p => p.Description)
                .HasColumnName("Description")
                .HasColumnAnnotation("Description", new IndexAnnotation(new IndexAttribute() { IsUnique = true}));

            ToTable("Products");
        }
    }
}
