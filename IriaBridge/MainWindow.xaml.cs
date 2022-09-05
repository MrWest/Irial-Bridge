using CommonServiceLocator;
using FirstFloor.ModernUI.Windows.Controls;
using IriaBridge.Presenter;
using IriaBridge.ViewModel;
using IriaBridge.Views;
using IriaBridge.Views.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IriaBridge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(INameablePresenter), typeof(MainWindow), new PropertyMetadata(null, OnSelectedItemChanged));

        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowingItemProperty = DependencyProperty.Register("ShowingItem", typeof(INameablePresenter), typeof(MainWindow), new PropertyMetadata(null, OnSelectedItemChanged));

        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty NavigateProperty = DependencyProperty.Register("Navigate", typeof(ICommand), typeof(MainWindow), new PropertyMetadata(new RelayCommand<string>(ExecuteNavigate, CanExecuteNavigate)));

        private static bool CanExecuteNavigate(string obj)
        {
            throw new NotImplementedException();
        }

        private static void ExecuteNavigate(string obj)
        {
            throw new NotImplementedException();
        }

        private static void OnSelectedItemChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((MainWindow)o).NavigeteOnNewItem((INameablePresenter)e.NewValue);
        }

        private void NavigeteOnNewItem(INameablePresenter newValue)
        {
            if(newValue != null )
            {
                ShowingItem = newValue;
                var interfaces = ShowingItem.GetType().GetInterfaces();
                if(interfaces.Contains(typeof(IItemPresenter)))
                    ContentSource = new Uri("/Views/ItemView.xaml", UriKind.Relative);
                else
                    ContentSource = new Uri("/Views/BridgeItemView.xaml", UriKind.Relative);
                SelectedItem = null;
            }
        }

        protected override void ContentSourceOnChange(Uri newValue)
        {
            base.ContentSourceOnChange(newValue);
            if (newValue == null) return;
            //if (newValue.OriginalString != "/Views/ItemView.xaml")
            //    SelectedItem = null;
        }

        private CartViewModel _cartViewModel;

        public MainWindow()
        {
           // this.ContentLoader = new ContentLoader(new ModelViewModel());
            InitializeComponent();
           
        }


        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public INameablePresenter SelectedItem
        {
            get { return (INameablePresenter)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public INameablePresenter ShowingItem
        {
            get { return (INameablePresenter)GetValue(ShowingItemProperty); }
            set { SetValue(ShowingItemProperty, value); }
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public ICommand Navigate
        {
            get { return (ICommand)GetValue(NavigateProperty); }
            set { SetValue(NavigateProperty, value); }
        }


    }
}
