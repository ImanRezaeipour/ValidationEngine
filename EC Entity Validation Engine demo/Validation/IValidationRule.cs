// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidationRule.cs" company="ExicitingCode">
//    Demo application of simple Business Rule Engine. All code is free to use as it is, but use it on your own risk.
// </copyright>
// <summary>
//   ValidationRule interface for abstracting implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EC.EntityValidationEngine.Validation
{
    /// <summary>
    /// ValidationRule interface for abstracting implementation.
    /// </summary>
    public interface IValidationRule
    {
        /// <summary>
        /// Gets or sets PropertyName. This is the name of the property which rule applies.
        /// </summary>
        string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets ErrorMessage. This is the error message of the validation object.
        /// </summary>
        ErrorObject ErrorMessageObject { get; set; }

        /// <summary>
        /// Validation method that contains validation implmentation. Needs to be implemented on the derived objects.
        /// </summary>
        /// <param name="businessObject">
        /// Business object to validate.
        /// </param>
        /// <returns>
        /// Returns true if validation was successful.
        /// </returns>
        bool Validate(ValidatableObjectBase businessObject);
    }
}
