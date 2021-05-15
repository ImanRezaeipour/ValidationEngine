// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityValidationRule.cs" company="ExcitingCode">
//   Demo application of simple Business Rule Engine. All code is free to use as it is, but use it on your own risk.
// </copyright>
// <summary>
//   Defines the IdentityValidationRule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;

namespace EC.EntityValidationEngine.Validation.BusinessRules
{
    /// <summary>
    /// Validation rule for identifiers like integer (primary key style) or Guid.
    /// </summary>
    public class IdentityValidationRule : ValidationRuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityValidationRule"/> class.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to validate.
        /// </param>
        public IdentityValidationRule(string propertyName) : base(propertyName)
        {
        }

        /// <summary>
        /// Validate the given object. Handles integer and Guid type identifiers.
        /// </summary>
        /// <param name="businessObject">
        /// The business object to validate.
        /// </param>
        /// <returns>
        /// Returns true if validation were succesful.
        /// </returns>
        public override bool Validate(ValidatableObjectBase businessObject)
        {
            try
            {
                // Get identity property from business object
                var identity = GetPropertyValue(businessObject);
                
                // If identity is integer check that it is 0 or positive value
                if (identity.GetType() == typeof(int))
                {
                    int id;
                    if (int.TryParse(identity.ToString(), out id))
                    {
                        return id >= 0;
                    }

                    // Parse failed.
                    return false;
                }

                // If identity is GUID check that parsing is successful
                if (identity.GetType() == typeof(Guid))
                {
                    Guid id;
                    if (Guid.TryParse(identity.ToString(), out id))
                    {
                        // If id is empty return false;
                        return id != Guid.Empty;
                    }

                    // Parse failed
                    return false;
                }

                // No match on types return false
                return false;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }
    }
}
