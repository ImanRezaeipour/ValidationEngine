using EC.EntityValidationEngine.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidationEngineTests.Validation
{
    [TestClass()]
    public class ErrorObjectTest
    {
        [TestMethod]
        public void Get_detailed_error_message_with_custom_message_should_return_defined_custom_message()
        {
            var target = new ErrorObject("Name", this.GetType());
            var errorMessage = "Detailed error message";
            target.SetDetailedErrorMessage(errorMessage);

            Assert.AreEqual(errorMessage, target.GetDetailedErrorMessage());
        }

        [TestMethod]
        public void Get_detailer_error_message_with_default_error_message()
        {
            var target = new ErrorObject("Name", this.GetType());
            Assert.IsTrue(target.GetDetailedErrorMessage().Length > 0);
        }
       
    }
}
