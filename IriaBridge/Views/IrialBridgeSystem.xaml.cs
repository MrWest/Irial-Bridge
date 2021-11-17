using IriaBridge.SystemSettings;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace IriaBridge.Views
{
    /// <summary>
    /// Interaction logic for LanguageSettings.xaml
    /// </summary>
    public partial class IrialBridgeSystem : System.Windows.Controls.UserControl
    {
        public IrialBridgeSystem()
        {
            InitializeComponent();
        }

        private void LocalRepositoryButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = this.DataContext as BridgeSettingsPresenter;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    settings.LocalRepository = fbd.SelectedPath;
                }
            }
        }

        private void ExportDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = this.DataContext as BridgeSettingsPresenter;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    settings.ExportDirectory = fbd.SelectedPath;
                }
            }
        }
    }
}
