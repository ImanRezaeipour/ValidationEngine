// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegexValidationRule.cs" company="ExcitingCode">
//   Demo application of simple Business Rule Engine. All code is free to use as it is, but use it on your own risk.
// </copyright>
// <summary>
//   Regular expression valdation rule. Regular expression can be normally in the business object when attaching the validation rule to it.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace EC.EntityValidationEngine.Validation.BusinessRules
{
    /// <summary>
    /// Regular expression valdation rule. Regular expression can be normally in the business object when attaching the validation rule to it.
    /// </summary>
    public class RegexValidationRule : ValidationRuleBase
    {
        /// <summary>
        /// Regular expression pattern.
        /// </summary>
        private readonly string expression;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RegexValidationRule"/> class.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to validate.
        /// </param>
        /// <param name="expression">
        /// The regular expression pattern.
        /// </param>
        public RegexValidationRule(string propertyName, string expression) : base(propertyName)
        {
            this.expression = expression;
            var errorMessage = propertyName + " did not meet pattern requirement. Pattern = " + this.expression;
            this.ErrorMessageObject = new ErrorObject(propertyName, this.GetType(), errorMessage);
        }

        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="businessObject">
        /// The business object to validate
        /// </param>
        /// <returns>
        /// Returns true if the validation were successful.
        /// </returns>
        public override bool Validate(ValidatableObjectBase businessObject)
        {
            try
            {
                // Get property from the given business object
                var property = this.GetPropertyValue(businessObject).ToString();

                // If regular expression is empty, throw ArgumentException
                // If expression is null and match is called, it counts as success, but I wanted to cut that out.
                if (string.IsNullOrEmpty(this.expression))
                {
                    throw new ArgumentException("Expression value is not set. Currently RegexValidationRule does not support empty validation expression.");
                }

                // Match propertys value to the given expression
                return Regex.Match(property, this.expression).Success;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }
    }
}
