using IriaBridge.Domain;
using IriaBridge.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using IriaBridge.Presenter;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using IriaBridge.DataAccess;

namespace IriaBridge.ViewModel
{
    public class ViewModelBase<T, TPresenter, TApplication, TRepository>: INotifyPropertyChanged, IViewModelBase
        where T: Entity 
        where TPresenter: IGenericPresenter<T>
        where TRepository: Repository<T>
        where TApplication: ApplicationBase<T, TRepository>
    {
        
        TApplication _application = ServiceLocator.Current.GetInstance<TApplication>();
        protected virtual TApplication ApplicationService { get { return _application; } }

        ICollection<TPresenter> _items = new ObservableCollection<TPresenter>();
        ICollection<TPresenter> _lazyItems = new ObservableCollection<TPresenter>();
        public ICollection<TPresenter> Items { get { return _items; } }

        public int Count { get { return _items.Count; } }

        bool _isLoaded = false;
        public bool IsLoaded { get { return _isLoaded; } }

        public ViewModelBase()
        {
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
        /// Creates a new presenter view model for the given item.
        /// </summary>
        /// <param name="item">The item a presenter view model is going to be created for.</param>
        /// <returns>
        /// A new instance of type <typeparamref name="TPresenter"/> decorating the item given in
        /// <paramref name="item"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        protected virtual TPresenter CreatePresenterFor(T item)
        {
            if (Equals(item, null))
                throw new ArgumentNullException("item");

            var presenter = ServiceLocator.Current.GetInstance<TPresenter>();
            presenter.Object = item;

            return presenter;
        }


        /// <summary>
        /// Loads the items from the data source.
        /// </summary>
        public virtual async 

        /// <summary>
        /// Loads the items from the data source.
        /// </summary>
        void Load()
        {

            _isLoaded = false;
            if (_lazyItems.Count > 0)
            {
                _items = _lazyItems;
            }
            else
            {
                _items.Clear();


                foreach (T item in ApplicationService.Entities)
                {
                    TPresenter presenter = CreatePresenterFor(item);
                    _items.Add(presenter);
                }


                _isLoaded = true;
                NotifyPropertyChanged("Items");

            }


           


        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Notify()
        {
            _isLoaded = true;
            NotifyPropertyChanged("Items");
        }
        public void LazyLoad()
        {
            _lazyItems.Clear();
            foreach (T item in ApplicationService.Entities)
            {
                TPresenter presenter = CreatePresenterFor(item);
                _lazyItems.Add(presenter);
            }

        }
    }
}
