using CommonServiceLocator;
using IriaBridge.Business;
using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class PresenterBase<T, TApplication> : IGenericPresenter<T>, IEntityPresenter, INotifyPropertyChanged
        where T : Entity
        where TApplication : IApplicationBase<T>
    {
        TApplication _application = ServiceLocator.Current.GetInstance<TApplication>();
        public T Object { get; set; }
        public int Id { get { return Object.Id; } }

        /// <summary>
        /// Commands to save the changes made to the underlying entity, sending an Update call to the services.
        /// </summary>
        /// <returns>An enumerable of strings being the errors there were found in the Update process (if any); or empty one in no errors where present.</returns>
        protected virtual bool UpdateEntity(List<string> errors)
        {

           
                // Do nothing if the entity cannot be updated or there cannot be executed the update altogether
                if (_application.CanUpdate(Object))
                    return false;

                try
                {
                    // Update the entity
                    _application.UpdateEntity(Object);
                    return true;
                }
                catch (Exception exception)
                {
                    // In case of validation errors, register them
                    errors.Add(exception.Message);
                }

                return false;
           
        }


        protected virtual bool SetProperty<TValue>(Action<TValue> setter, TValue value, [CallerMemberName] string propertyName = null)
        {
            if (setter == null)
                throw new ArgumentNullException("setter");
            if (propertyName == null)
                throw new ArgumentNullException("propertyName");

            bool isPropertySet = true;

            // Check whether the actual and the new values are equal, in which case, there cannot be set the property, no need to
            TValue actualValue = GetValue<TValue>(propertyName);
            if (Equals(actualValue, value) || ReferenceEquals(actualValue, value))
                return false;

            // Otherwise, set the property's new value
            setter(value);

            // Before continuing, the entity must be validated
            //string statusBarMessage = SucessfullyUpdatedMessage.EasyFormat(Object);
            List<string> errors = new List<string>();
            //IEnumerable<ValidationResult> validationErrors = new ValidationResult[0];

            // If validation goes well, command the services to save the property new value, and record any error that may come up in the process
            if (true)
                isPropertySet = UpdateEntity(errors);

            // If then there are errors, then aggregate them all in a format that the validation engine understands
            //if (errors.Any())
            //{
            //    validationErrors = errors.Aggregate(new List<ValidationResult>(), (list, error) =>
            //    {
            //        list.Add(new ValidationResult(false, error));
            //        return list;
            //    });

            //    // Change the notification message to a one notifying about the validation errors
            //    statusBarMessage = GetValidationErrorMessage();
            //    isPropertySet = false;
            //}

            //// Returns the property to its former value if there were errors
            //if (!isPropertySet)
            //{
            //    setter(actualValue);
            //    if (!errors.Any())
            //        statusBarMessage = GetErrorMessage();
            //}

            //// Now the set the found errors (empty is the entity is value, not empty when it has errors) for the property
            //SetErrors(propertyName, validationErrors);

            //// Send the notification to the user
            //if (AllowUdpateNotifications)
            //    StatusBarServices.SignalText(statusBarMessage);

            // Notify WPF that the property has changed its value
            OnPropertyChanged(propertyName);

            return isPropertySet;
        }
        

        private TValue GetValue<TValue>(string propertyName)
        {
            Type type = GetType();
            PropertyInfo property = type.GetProperty(propertyName);
            return (TValue)property.GetValue(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
