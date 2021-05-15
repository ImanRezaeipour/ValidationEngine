using System;
using EC.EntityValidationEngine.BusinessObjects.Base;
using EC.EntityValidationEngine.Validation.BusinessRules;

namespace EC.EntityValidationEngine.BusinessObjects
{
    /// <summary>
    /// Customer business object. Created for the demostration purposes. 
    /// </summary>
    public class CustomerEntity : EntityBase 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerEntity"/> class.
        /// </summary>
        public CustomerEntity()
        {
            // Add business rule: The identifier have to be 0 or positive value
            this.AddValidationRule(new IdentityValidationRule("Id"));

            // Add business rule: The customer name have to be longer than 2 letters and no longer than 10
            this.AddValidationRule(new RegexValidationRule("Name", @"^.{3,10}$"));
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string Name { get; set; }
    }
}
