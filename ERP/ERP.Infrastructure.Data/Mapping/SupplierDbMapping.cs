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

            Property(p => p.Address.AddressLine).HasColumnName("AddressLine");
            Property(p => p.Address.Number).HasColumnName("Number");
            Property(p => p.Address.Adjunct).HasColumnName("Adjunct");
            Property(p => p.Address.District).HasColumnName("District");
            Property(p => p.Address.ZipCode).HasColumnName("ZipCode");
            Property(p => p.Address.City).HasColumnName("City");
            Property(p => p.Address.State).HasColumnName("State");

            Property(p => p.FinancialAddress.AddressLine).HasColumnName("FinancialAddressLine");
            Property(p => p.FinancialAddress.Number).HasColumnName("FinancialNumber");
            Property(p => p.FinancialAddress.Adjunct).HasColumnName("FinancialAdjunct");
            Property(p => p.FinancialAddress.District).HasColumnName("FinancialDistrict");
            Property(p => p.FinancialAddress.ZipCode).HasColumnName("FinancialZipCode");
            Property(p => p.FinancialAddress.City).HasColumnName("FinancialCity");
            Property(p => p.FinancialAddress.State).HasColumnName("FinancialState");

            ToTable("Suppliers");
        }
    }
}
