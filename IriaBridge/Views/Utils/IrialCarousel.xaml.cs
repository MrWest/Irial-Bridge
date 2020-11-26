using IriaBridge.Presenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IriaBridge.Views.Utils
{
    /// <summary>
    /// Interaction logic for IrialCarousel.xaml
    /// </summary>
    public partial class IrialCarousel : UserControl
    {
        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty ImagesProperty = DependencyProperty.Register("Images", typeof(ICollection<ImagePresenter>), typeof(IrialCarousel), new PropertyMetadata(new ObservableCollection<ImagePresenter>()));

        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedImageProperty = DependencyProperty.Register("SelectedImage", typeof(ImagePresenter), typeof(IrialCarousel));

        public IrialCarousel()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public ImagePresenter SelectedImage
        {
            get { return (ImagePresenter)GetValue(SelectedImageProperty); }
            set { SetValue(SelectedImageProperty, value); }
        }
        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public ICollection<ImagePresenter> Images
        {
            get { return (ICollection<ImagePresenter>)GetValue(ImagesProperty); }
            set { SetValue(ImagesProperty, value); }
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible && bottomList.SelectedItem == null && bottomList.Items.Count > 0)
                SelectedImage = (ImagePresenter)bottomList.Items.GetItemAt(0);
        }
    }
}
