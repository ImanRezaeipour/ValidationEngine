// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorObject.cs" company="ExcitingCode">
//    Demo application of simple Business Rule Engine. All code is free to use as it is, but use it on your own risk.
// </copyright>
// <summary>
//   Default error information container. This class contains basic information about the validation error.
//   To get more specific implementations extend this class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Text;

namespace EC.EntityValidationEngine.Validation
{
    /// <summary>
    /// Default error information container. This class contains basic information about the validation error.
    /// To get more specific implementations extend this class.
    /// </summary>
    public class ErrorObject : IErrorObject
    {
        /// <summary>
        /// Backfield for the detailed error message.
        /// </summary>
        private string detailedErrorMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorObject"/> class. Uses default error message.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property which validation is applied.
        /// </param>
        /// <param name="validationRuleType">
        /// The type of the validation Rule.
        /// </param>
        public ErrorObject(string propertyName, Type validationRuleType)
        {
            this.PropertyName = propertyName;

            // Set default error text
            this.ErrorMessage = propertyName + " is not valid.";
            this.ValidationRuleType = validationRuleType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorObject"/> class.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property which validation is applied.
        /// </param>
        /// <param name="validationRuleType">
        /// The validation Rule Type.
        /// </param>
        /// <param name="errorMessage">
        /// The user friendly error message.
        /// </param>
        public ErrorObject(string propertyName, Type validationRuleType,  string errorMessage) : this(propertyName, validationRuleType)
        {
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets or sets type of business object.
        /// </summary>
        public Type BusinessObjectType { get; protected set; }

        /// <summary>
        /// Gets or sets type of ValidationRule.
        /// </summary>
        public Type ValidationRuleType { get; protected set; }

        /// <summary>
        /// Gets or sets PropertyName. This is the name of the property that raised error.
        /// </summary>
        public string PropertyName { get; protected set; }

        /// <summary>
        /// Gets or sets ErrorMessage. This is user friendly error message.
        /// </summary>
        public string ErrorMessage { get; protected set; }

        /// <summary>
        /// Sets more detailed error message then ErrorMessage. Value is used for detailed logging and such. DetailedErrorMessage is fetched 
        /// via virtual GetDetailedErrorMessage()-method.
        /// Maybe the best way to create detailed error message is to build it in the Validate()-method in the ValidationRule implementation.
        /// </summary>
        /// <param name="errorMessage">
        /// The detailed error message
        /// </param>
        public void SetDetailedErrorMessage(string errorMessage)
        {
            this.detailedErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets more detailed error message than ErrorMessage. 
        /// If DetailedErrorMessage is set to internal backing field by using SetDetailedErrorMessage(string)-method, that is used.
        /// If backing field is empty, then message is composed here.
        /// Detailed Error message can be used for detailed logging and such. Override when needing more information to the message.
        /// </summary>
        /// <returns>
        /// Detailed error message.
        /// </returns>
        public virtual string GetDetailedErrorMessage()
        {
            if (string.IsNullOrEmpty(this.detailedErrorMessage))
            {
                var builder = new StringBuilder();
                if (this.BusinessObjectType != null)
                {
                    builder.AppendLine(this.BusinessObjectType + "." + this.PropertyName + " validation failed.");
                }
                else
                {
                    builder.AppendLine(this.PropertyName + " validation failed.");
                }

                builder.AppendLine("Validation was done using instance of " + this.ValidationRuleType);
                builder.AppendLine("ErrorMessage : " + this.ErrorMessage);

                return builder.ToString();
            }
            
            return this.detailedErrorMessage;
        }
    }
}
