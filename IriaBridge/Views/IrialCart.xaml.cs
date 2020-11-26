using CommonServiceLocator;
using IriaBridge.ViewModel;
using System.Windows.Controls;

namespace IriaBridge.Views
{
    /// <summary>
    /// Interaction logic for IrialCart.xaml
    /// </summary>
    public partial class IrialCart : UserControl
    {
        public IrialCart()
        {
            InitializeComponent();
            DataContext = ServiceLocator.Current.GetInstance(typeof(CartViewModel));
        }
    }
}
