// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationRuleBase.cs" company="ExcitingCode">
//   Demo application of simple Validation Rule Engine. All code is free to use as it is, but use it on your own risk.
// </copyright>
// <summary>
//   Abstract base class for the validable business rule (ValidationRule). 
//   Validation Rules needs to override public abstract bool Validate(BusinessObject businessObject) method and handle validation there.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EC.EntityValidationEngine.Validation
{
    /// <summary>
    ///   Abstract base class for the validable Validation Rule. 
    ///   Validation / Validation Rules needs to override public abstract bool Validate(BusinessObject businessObject) method and handle validation there.
    /// </summary>
    public abstract class ValidationRuleBase : IValidationRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRuleBase"/> class. 
        /// </summary>
        /// <param name="propertyName">
        /// The property which validation rule is hooked with.
        /// </param>
        protected ValidationRuleBase(string propertyName)
        {
            this.PropertyName = propertyName;

            // Create errorObject with default error message
            this.ErrorMessageObject = new ErrorObject(propertyName, this.GetType());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRuleBase"/> class. 
        /// </summary>
        /// <param name="propertyName">
        /// The property which validation rule is hooked with.
        /// </param>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        protected ValidationRuleBase(string propertyName, string errorMessage) : this(propertyName)
        {
            this.ErrorMessageObject = new ErrorObject(propertyName, this.GetType(), errorMessage);
        }

        /// <summary>
        /// Gets or sets PropertyName. This is the name of the property which rule applies.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets ErrorMessage. This is the error message of the validation object.
        /// </summary>
        public ErrorObject ErrorMessageObject { get; set; }

        /// <summary>
        /// Validation method that contains validation implmentation. Needs to be implemented on the derived objects.
        /// </summary>
        /// <param name="businessObject">
        /// Business object to validate.
        /// </param>
        /// <returns>
        /// Returns true if validation was successful.
        /// </returns>
        public abstract bool Validate(ValidatableObjectBase businessObject);

        /// <summary>
        /// Gets value from the business object using simple reflection.
        /// </summary>
        /// <param name="businessObject">
        /// Business object to inspect
        /// </param>
        /// <returns>
        /// Returns Property's object or null
        /// </returns>
        protected object GetPropertyValue(ValidatableObjectBase businessObject)
        {
            return businessObject.GetType().GetProperty(this.PropertyName).GetValue(businessObject, null);
        }
    }
}
