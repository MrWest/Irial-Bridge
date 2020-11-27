using System;
using System.Collections.Generic;
using System.IO;
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
namespace IriaBridge.Views
{
    /// <summary>
    /// Interaction logic for Introduction.xaml
    /// </summary>
    public partial class Introduction : UserControl
    {
        public Introduction()
        {
            var initImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
               Path.Combine(IriaBridge.Properties.Settings.Default.ImgMediaRelativePath, IriaBridge.Properties.Settings.Default.ImgMediaFile));
            Background = new ImageBrush() { ImageSource = new BitmapImage( new Uri(initImgPath))};
        }
    }
}
