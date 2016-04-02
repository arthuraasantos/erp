using System;
using ERP.Domain.Entities.Common;
using ERP.Domain.Entities.Organizations;
using ERP.Domain.Entities.Products;
using ERP.Domain.Entities.Products.PricePlans;
using ERP.Domain.Entities.Products.Sections;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Domain.Entities.Suppliers;

namespace ERP.Infrastructure.Data.EntitiesSeed
{
    public static class SeedInitialize
    {
        private static Guid SectionId { get; set; }
        private static Guid PricePlanId { get; set; }
        private static Guid StockId { get; set; }
        private static Guid ProductId { get; set; }
        private static Guid StockProductId { get; set; }

        private static PricePlan PricePlan { get; set; }

        public static Organization InitializeOrganization()
        {
            return new Organization()
            {
                Id = Guid.NewGuid(),
                Name = "ERP [Desenvolvimento]",
                Email = "contato@erp.com.br",
                RegistrationName = "ERP DESENVOLVIMENTOS",
                CreateDate = DateTime.UtcNow,
                Address = new Address()
                {
                    AddressLine = "Estrada do Campinho",
                    Number = "1506",
                    Adjunct = "4º andar SALA 304",
                    District = "Campo grande",
                    ZipCode = "23070450",
                    City = "Rio de Janeiro",
                    State = "RJ"
                }
            };
        }
                
        public static Section InitializeSection(Guid organizationId)
        {
            SectionId = Guid.NewGuid();
            var section = new Section()
            {
                Id = SectionId,
                OrganizationId = organizationId,
                Description = "Informática",
                Location = "Galpão A",
                CreateDate = DateTime.UtcNow
            };
            return section;
        }

        public static PricePlan InitializePricePlan(Guid organizationId)
        {
            PricePlanId = Guid.NewGuid();
            var pricePlan = new PricePlan()
            {
                Id = PricePlanId,
                OrganizationId = organizationId,
                Description = "Vendas Varejo",
                AliquotValue = 30.0m
            };
            PricePlan = pricePlan;
            return pricePlan;
        }

        public static Stock InitiliazeStock(Guid organizationId)
        {
            StockId = Guid.NewGuid();
            return new Stock()
            {
                Id = StockId,
                OrganizationId =  organizationId,
                Description = "Estoque Matriz",
            };
        }

        public static Product InitializeProduct(Guid organizationId, Section section, PricePlan pricePlan)
        {
            ProductId = Guid.NewGuid();
            return new Product()
            {
                Id = ProductId,
                OrganizationId =  organizationId,
                Description = "Mouse sem fio Microsoft",
                EanCode = "20000000039384",
                CreateDate = DateTime.UtcNow,
                Section = section,
                SectionId = SectionId,
                PricePlan = pricePlan,
                PricePlanId = PricePlanId
            };
        }

        public static StockProduct InitializeStockProduct(Guid organizationId, Guid productId, Guid stockId)
        {
            StockProductId = Guid.NewGuid();
            var stockProduct = new StockProduct()
            {
                OrganizationId = organizationId,
                Id = StockProductId,
                ProductId = ProductId,
                StockId = StockId
            };
            stockProduct.AddItem(1);

            return stockProduct;
        }

        public static Supplier InitializeSupplier(Guid organizationId)
        {
            return new Supplier()
            {
                OrganizationId = organizationId,
                Id = Guid.NewGuid(),
                Name = "Nokia SA",
                Email = "contato@nokia.co",
                RegistrationName = "Nokia Serviços Alternados",
                FantasyName = "Nokia Brasil SA",
                StateRegistration = "213123223",
                CityRegistration = "987998472",
                CreateDate = DateTime.UtcNow,
                ContactPeople = "Mark Nokiaberg",
                CpfCnpj = "34495968577685",
                Comments = "fornecedor de teste [Desenvolvimento]",
                Phone = "34243243",
                Address = new Address()
                {
                    AddressLine = "Rua Marginal Tiete",
                    Number = "34566",
                    Adjunct = "25º andar SALA 2587",
                    District = "Centro",
                    ZipCode = "2800937",
                    City = "São Paulo",
                    State = "RJ"
                },
                FinancialAddress = new Address()
                {
                    AddressLine = "Rua Marginal Tiete",
                    Number = "34566",
                    Adjunct = "25º andar SALA 2587",
                    District = "Centro",
                    ZipCode = "2800937",
                    City = "São Paulo",
                    State = "RJ"
                }
            };
        }
    }
}
