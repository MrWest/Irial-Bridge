using System;
using System.Collections.Generic;
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
using WPFLocalization;

namespace IriaBridge.Views
{
    /// <summary>
    /// Interaction logic for LanguageSettings.xaml
    /// </summary>
    public partial class LanguageSettings : UserControl
    {
        public LanguageSettings()
        {
            InitializeComponent();
            LangCombo.SelectedItem = LangCombo.Items.Cast<ComboBoxItem>().FirstOrDefault(itm => LocalizationManager.UICulture.ToString().Contains(itm.Content.ToString().ToLower()));

        }

        private void LangCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocalizationManager.UICulture = new CultureInfo(((ComboBoxItem)e.AddedItems[0]).Content.ToString());
        }
    }
}
