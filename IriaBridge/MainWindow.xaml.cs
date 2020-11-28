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
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(IItemPresenter), typeof(MainWindow), new PropertyMetadata(null, OnSelectedItemChanged));

        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowingItemProperty = DependencyProperty.Register("ShowingItem", typeof(IItemPresenter), typeof(MainWindow), new PropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((MainWindow)o).NavigeteOnNewItem((IItemPresenter)e.NewValue);
        }

        private void NavigeteOnNewItem(IItemPresenter newValue)
        {
            if(newValue != null )
            {
                ShowingItem = newValue;
                ContentSource = new Uri("/Views/ItemView.xaml", UriKind.Relative);
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
        public IItemPresenter SelectedItem
        {
            get { return (IItemPresenter)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public IItemPresenter ShowingItem
        {
            get { return (IItemPresenter)GetValue(ShowingItemProperty); }
            set { SetValue(ShowingItemProperty, value); }
        }


    }
}
