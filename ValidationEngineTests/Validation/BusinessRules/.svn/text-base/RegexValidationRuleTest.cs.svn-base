using EC.EntityValidationEngine.Validation;
using EC.EntityValidationEngine.Validation.BusinessRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidationEngineTests.Validation.BusinessRules
{
    [TestClass()]
    public class RegexValidationRuleTest
    {
        [TestMethod]
        public void Validate_property_type_of_string_with_any_value_should_be_valid()
        {
            var propertyName = "StringProperty";
            var target = new RegexValidationRule(propertyName, @".");
            var businessObject = new TestEntity() { StringProperty = "Test text" };

            Assert.IsTrue(target.Validate(businessObject));
        }

        [TestMethod]
        public void Validate_empty_property_type_of_string_with_any_value_should_be_invalid()
        {
            var propertyName = "StringProperty";
            var target = new RegexValidationRule(propertyName, @".");
            var businessObject = new TestEntity() { StringProperty = "" };

            Assert.IsFalse(target.Validate(businessObject));
        }

        [TestMethod]
        public void Validate_property_type_of_string_with_empty_expression_should_be_invalid()
        {
            var propertyName = "StringProperty";
            var target = new RegexValidationRule(propertyName, "");
            var businessObject = new TestEntity() { StringProperty = "Test text" };

            Assert.IsFalse(target.Validate(businessObject));
        }

        [TestMethod]
        public void Validate_empty_property_type_of_string_with_empty_expression_should_be_invalid()
        {
            var propertyName = "StringProperty";
            var target = new RegexValidationRule(propertyName, "");
            var businessObject = new TestEntity() { StringProperty = "" };

            Assert.IsFalse(target.Validate(businessObject));
        }

        protected class TestEntity : ValidatableObjectBase
        {
            public string StringProperty { get; set; }
        }
    }
}
