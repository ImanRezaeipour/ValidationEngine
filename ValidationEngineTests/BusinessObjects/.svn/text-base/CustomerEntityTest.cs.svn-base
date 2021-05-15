using EC.EntityValidationEngine.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ValidationEngineTests.BusinessObjects
{
    [TestClass()]
    public class CustomerEntityTest
    {
        [TestMethod()]
        public void Validate_with_positive_integer_should_be_valid()
        {
            var target = new CustomerEntity { Id = 12, Name="Mat" };

            Assert.IsTrue(target.Validate());
            Assert.IsTrue(target.ValidationErrors.Count == 0);
        }

        [TestMethod()]
        public void Validate_property_by_name_with_positive_integer_should_be_valid()
        {
            var target = new CustomerEntity { Id = 12, Name = "Mat" };

            Assert.IsTrue(target.ValidatePropertyByName("Id"));
            Assert.IsTrue(target.ValidationErrors.Count == 0);
        }

        [TestMethod()]
        public void Validate_with_negative_integer_should_be_invalid()
        {
            var target = new CustomerEntity { Id = -1, Name = "Mat" };
            Assert.IsFalse(target.Validate());
            Assert.IsTrue(target.ValidationErrors.Count > 0);
        }

        [TestMethod()]
        public void Validate_property_by_name_with_negative_integer_should_be_invalid()
        {
            var target = new CustomerEntity { Id = -1, Name = "Mat" };

            Assert.IsFalse(target.ValidatePropertyByName("Id"));
            Assert.IsTrue(target.ValidationErrors.Count > 0);
        }

        [TestMethod()]
        public void Validate_with_zero_should_be_valid()
        {
            var target = new CustomerEntity { Id = 0, Name = "Mat" };

            Assert.IsTrue(target.Validate());
        }

        [TestMethod()]
        public void Validate_property_by_name_with_zero_should_be_valid()
        {
            var target = new CustomerEntity { Id = 0, Name = "Mat" };

            Assert.IsTrue(target.ValidatePropertyByName("Id"));
        }
    }
}
