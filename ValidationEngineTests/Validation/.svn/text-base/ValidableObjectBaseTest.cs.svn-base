using EC.EntityValidationEngine.Validation;
using EC.EntityValidationEngine.Validation.BusinessRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace ValidationEngineTests.Validation
{
    [TestClass()]
    public class ValidableObjectBaseTest
    {
        [TestMethod]
        public void Add_new_rule_to_entity_and_it_is_attached_to_rule_list()
        {
            var entity = new TestValidEntity();           
            Assert.IsTrue(entity.HasValidationRulesAttached);
        }

        [TestMethod]
        public void Validate_business_entity_with_mocked_validation_rule_should_be_valid()
        {
            var entity = new TestValidEntity();
            Assert.IsTrue(entity.Validate());
        }

        [TestMethod]
        public void Validate_business_entitys_ID_property_with_mocked_validation_rule_should_be_valid()
        {
            var entity = new TestValidEntity();
            Assert.IsTrue(entity.ValidatePropertyByName("Id"));
            Assert.IsTrue(entity.ValidationErrors.Count == 0);
        }

        [TestMethod]
        public void Validate_business_entitys_Name_property_without_business_rule_attached_to_it_should_be_valid()
        {
            var entity = new TestValidEntity();
            Assert.IsTrue(entity.ValidatePropertyByName("Name"));
        }

        [TestMethod]
        public void Validate_business_entity_with_mocked_validation_rule_should_be_invalid_and_new_validation_error_should_be_added_to_the_entity()
        {
            var entity = new TestInvalidEntity();
            Assert.IsFalse(entity.Validate());
            Assert.IsTrue(entity.ValidationErrors.Count > 0);
        }

        [TestMethod]
        public void Validate_business_entitys_Id_property_with_mocked_validation_rule_should_be_invalid_and_new_validation_error_should_be_added_to_the_entity()
        {
            var entity = new TestInvalidEntity();
            Assert.IsFalse(entity.ValidatePropertyByName("Id"));
            Assert.IsTrue(entity.ValidationErrors.Count > 0);
        }

        protected class TestValidEntity : ValidatableObjectBase
        {
            public int Id { get; set; }

            public TestValidEntity()
            {
               var rule = new Mock<IValidationRule>();
               rule.Setup(x => x.ErrorMessageObject).Returns(new ErrorObject("Id", typeof(IdentityValidationRule)));
               rule.Setup(x => x.Validate(this)).Returns(true);
               

               this.AddValidationRule(rule.Object);
            }
        }

        protected class TestInvalidEntity : ValidatableObjectBase
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public TestInvalidEntity()
            {
                var rule = new Mock<IValidationRule>();
                rule.Setup(x => x.ErrorMessageObject).Returns(new ErrorObject("Id", typeof(IdentityValidationRule)));
                rule.Setup(x => x.PropertyName).Returns("Id");
                rule.Setup(x => x.Validate(this)).Returns(false);

                this.AddValidationRule(rule.Object);
            }
        }
    }
}
