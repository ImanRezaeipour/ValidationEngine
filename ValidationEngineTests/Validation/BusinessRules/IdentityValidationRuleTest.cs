using System;
using EC.EntityValidationEngine.Validation;
using EC.EntityValidationEngine.Validation.BusinessRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidationEngineTests.Validation.BusinessRules
{
    [TestClass()]
    public class IdentityValidationRuleTest
    {
        [TestMethod]
        public void Validate_Identity_type_of_integer_with_postive_value_validation_should_be_valid()
        {
            var propertyName = "IntId";
            var target = new IdentityValidationRule(propertyName);
            var businessObject = new TestEntity() { IntId = 10 };
             
            Assert.IsTrue(target.Validate(businessObject));
        }

        [TestMethod]
        public void Validate_Identity_type_of_integer_with_negative_value_validation_should_return_be_invalid()
        {
            var propertyName = "IntId";
            var target = new IdentityValidationRule(propertyName);
            var businessObject = new TestEntity() { IntId = -90 };

            Assert.IsFalse(target.Validate(businessObject));
        }

        [TestMethod]
        public void Validate_Identity_type_of_integer_with_0_value_validation_should_be_valid()
        {
            var propertyName = "IntId";
            var target = new IdentityValidationRule(propertyName);
            var businessObject = new TestEntity() { IntId = 10 };

            Assert.IsTrue(target.Validate(businessObject));
        }

        [TestMethod]
        public void Validate_Identity_type_of_guid_with_generated_guid_validation_should_be_valid()
        {
            var propertyName = "GuidId";
            var target = new IdentityValidationRule(propertyName);
            var businessObject = new TestEntity() { GuidId = Guid.NewGuid() };

            Assert.IsTrue(target.Validate(businessObject));
        }

        [TestMethod]
        public void Validate_Identity_type_of_guid_with_empty_guid_validation_should_be_invalid()
        {
            var propertyName = "GuidId";
            var target = new IdentityValidationRule(propertyName);
            var businessObject = new TestEntity() { GuidId = Guid.Empty };

            Assert.IsFalse(target.Validate(businessObject));
        }

        protected class TestEntity : ValidatableObjectBase
        {
            public int IntId { get; set; }
            public Guid  GuidId { get; set; }
        }
    }
}
