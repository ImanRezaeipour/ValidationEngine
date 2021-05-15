// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatableobjectBase.cs" company="ExcitingCode">
//    Demo application of simple Business Rule Engine. All code is free to use as it is, but use it on your own risk.
// </copyright>
// <summary>
//   Abstract base class for the entities. The base class implements basic functionality to attach business rules to the 
//   Entity and exposes Validate()-method to launch validation. Validation errors are exposed via ValidationErrors property.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace EC.EntityValidationEngine.Validation
{
    /// <summary>
    /// Abstract base class for the entities. The base class implements basic functionality to attach business rules to the 
    /// Entity and exposes Validate()-method to launch validation. Validation errors are exposed via ValidationErrors property.
    /// </summary>
    public abstract class ValidatableObjectBase
    {
        /// <summary>
        /// List of attached Business rules that are set to the business object.
        /// </summary>
        private readonly List<IValidationRule> validationRules;

        /// <summary>
        /// List of Validation errors from the attached business rules. If business rule check fails, new validation error is added.
        /// </summary>
        private readonly List<IErrorObject> validationErrors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatableObjectBase"/> class.
        /// </summary>
        protected ValidatableObjectBase()
        {
            this.validationRules = new List<IValidationRule>();
            this.validationErrors = new List<IErrorObject>();
        }

        /// <summary>
        /// Gets list of validations errors. List is populated when Validate()-method is called.
        /// </summary>
        public List<IErrorObject> ValidationErrors
        {
            get
            {
                return this.validationErrors;
            }
        }

        /// <summary>
        /// Gets a value indicating whether business object has rules attached.
        /// </summary>
        public bool HasValidationRulesAttached
        {
            get
            {
                return this.validationRules.Count > 0;
            }
        }
        
        /// <summary>
        /// Determines whether business object is valid. Creates a list of validation errors when called.
        /// </summary>
        /// <returns>True if there weren't any validation errors in the attached BusinessRules.</returns>
        public bool Validate()
        {
            var isValid = true;

            // Clear current error list
            this.validationErrors.Clear();

            // Run Validate method in all attached business rules and add validation errors to the entity if validation failed.
            foreach (var validationRule in this.validationRules.Where(rule => !rule.Validate(this)))
            {
                isValid = false;
                this.validationErrors.Add(validationRule.ErrorMessageObject);
            }

            return isValid;
        }

        /// <summary>
        /// Determines wheter business object's property is valid. Creates a list of validation errors when called.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to validate
        /// </param>
        /// <returns>
        /// Returns true if property is valid.
        /// </returns>
        public bool ValidatePropertyByName(string propertyName)
        {
            var isValid = true;

            // Clear current error list
            this.validationErrors.Clear();

            // Run Validate method in all business rules that are attached to the target property
            // If Validate()-method returns false, add validation error to the entity.
            foreach (var validationRule in this.validationRules.Where(
                rule => rule.PropertyName == propertyName && !rule.Validate(this)))
            {
                isValid = false;
                this.validationErrors.Add(validationRule.ErrorMessageObject);
            }

            return isValid;
        }

        /// <summary>
        /// Attach Validation Rule (business rule) to the entity.
        /// </summary>
        /// <param name="rule">Business rule to attach to the entity.</param>
        protected void AddValidationRule(IValidationRule rule)
        {
            this.validationRules.Add(rule);
        }
    }
}