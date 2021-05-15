using System.ComponentModel;
using EC.EntityValidationEngine.Validation;

namespace EC.EntityValidationEngine.BusinessObjects.Base
{
    /// <summary>
    /// Base class for the entities.
    /// </summary>
    public abstract class EntityBase : ValidatableObjectBase
    {
        /// <summary>
        /// Event for Property Chagned.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises PropertyChanged event. Use Extension method to raise property chagned events.
        /// </summary>
        /// <param name="propertyName">
        /// Propertys name.
        /// </param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
