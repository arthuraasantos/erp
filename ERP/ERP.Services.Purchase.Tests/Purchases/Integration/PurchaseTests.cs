using System;
using ERP.Services.PurchaseServices.Dtos.Purchases;
using ERP.Services.PurchaseServices.Interfaces.Purchases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Language.Flow;

namespace ERP.Services.Purchase.Tests.Purchases.Integration
{
    [TestClass]
    public class PurchaseTests
    {
        [TestMethod]
        public void CreateNewValidPurchaseAndReturnIsGuid()
        {
            var purchaseNewDto = new PurchaseNewDto();
            var purchaseService = new Mock<IPurchaseServiceOrganization>();
            var organizationId = Guid.NewGuid();
            purchaseService.Verify(t => t.Create(purchaseNewDto,organizationId));
            purchaseService.Setup(p => p.Create(purchaseNewDto, organizationId)).Returns(organizationId);
            
        }
    }
}
