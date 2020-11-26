using FirstFloor.ModernUI.Windows;
using IriaBridge.Presenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IriaBridge.ViewModel
{
    public class CartViewModel: DependencyObject, INotifyPropertyChanged
    {
        ICollection<IItemPresenter> _items = new ObservableCollection<IItemPresenter>();

        public ICollection<IItemPresenter> Items { get { return _items; } }


        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(CartViewModel), new PropertyMetadata(false));


        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set {
                SetValue(IsOpenProperty, value);
                NotifyPropertyChanged("IsOpen");
            }
        }

        public Action DoNotify { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AddItem(IItemPresenter item)
        {
            _items.Add(item);
            IsOpen = true;
            NotifyPropertyChanged("IsOpen");
            NotifyPropertyChanged("Items");
            if (DoNotify != null) DoNotify.Invoke();

        }


        private UICommand _open;

        private UICommand _close;

        public CartViewModel()
        {

            _open = new UICommand(param => IsOpen = true, param => true);

            _close = new UICommand(param => IsOpen = false, param => true);
            PropertyChanged += OnPropertyHasChanged;
        }

        /// <summary>
        /// Invoked when a property in the current entity presenter view model has been notified as changed.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">Arguments containing the details of the event.</param>
        protected virtual void OnPropertyHasChanged(object sender, PropertyChangedEventArgs e)
        {
        }
        /// <summary>
        /// Gets or sets the content loader.
        /// </summary>
        public ICommand Open
        {
            get { return _open; }
        }


        /// <summary>
        /// Gets or sets the content loader.
        /// </summary>
        public ICommand Close
        {
            get { return _close; }
        }
    }
}
