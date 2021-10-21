using CommonServiceLocator;
using IriaBridge.ViewModel;
using System;
using System.Collections.Generic;
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

namespace IriaBridge.Views
{
    /// <summary>
    /// Interaction logic for Models.xaml
    /// </summary>
    public partial class Scenes : UserControl
    {
        public Scenes()
        {
            
            InitializeComponent();
            //listDockPanel.DataContext = new ModelViewModel();
            //var viewmodel = listDockPanel.DataContext as ModelViewModel;
            //viewmodel.Load();

            //var leat = ServiceLocator.Current.GetInstance(typeof(CategoryViewModel)) as CategoryViewModel;
            //leat.Load();

            //cartContainer.DataContext = ServiceLocator.Current.GetInstance(typeof(CartViewModel));
        }
    }
}
