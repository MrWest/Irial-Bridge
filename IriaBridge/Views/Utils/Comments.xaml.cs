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
    /// Interaction logic for Comments.xaml
    /// </summary>
    public partial class Comments : UserControl
    {
        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty CommentsProperty = DependencyProperty.Register("CommentsSource", typeof(ICollection<CommentPresenter>), typeof(Comments), new PropertyMetadata(new ObservableCollection<CommentPresenter>()));

        public Comments()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public ICollection<CommentPresenter> CommentsSource
        {
            get { return (ICollection<CommentPresenter>)GetValue(CommentsProperty); }
            set { SetValue(CommentsProperty, value); }
        }
    }
}
