using System;

namespace EC.EntityValidationEngine.Validation
{
    /// <summary>
    /// ErrorObject interface for abstracting the implementation.
    /// </summary>
    public interface IErrorObject
    {
        /// <summary>
        /// Gets type of ValidationRule.
        /// </summary>
        Type ValidationRuleType { get; }

        /// <summary>
        /// Gets PropertyName. This is the name of the property that raised error.
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// Gets ErrorMessage. This is user friendly error message.
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Gets more detailed error message than ErrorMessage. 
        /// If DetailedErrorMessage is set to internal backing field by using SetDetailedErrorMessage(string)-method, that is used.
        /// If backing field is empty, then message is composed here.
        /// Detailed Error message can be used for detailed logging and such. Override when needing more information to the message.
        /// </summary>
        /// <returns>
        /// Detailed error message.
        /// </returns>
        string GetDetailedErrorMessage();
    }
}