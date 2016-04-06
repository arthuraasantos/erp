using System;
using ERP.Domain.Entities.Suppliers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERP.DomainTests.Units
{
    [TestClass]
    public class SupplierTest
    {
        [TestMethod]
        public void Test_IsValid()
        {
            var supplier = new Supplier();

            var isValid = supplier.IsValid();
            
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Test_IsActive()
        {
            var supplier = new Supplier() { DeleteDate = DateTime.UtcNow.Date };

            var isActive = supplier.IsActive();

            Assert.IsTrue(isActive);

        }
    }
}
