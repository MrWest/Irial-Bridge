using IriaBridge.Presenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class Comments: UserControl


    {
        /// <summary>
        /// Identifies the ContentLoader dependency property.
        /// </summary>
        public static readonly DependencyProperty CommentsSourceProperty = DependencyProperty.Register("CommentsSource", typeof(object), typeof(Comments), new PropertyMetadata(null));

        public Comments()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public object CommentsSource
        {
            get { return (object)GetValue(CommentsSourceProperty); }
            set { SetValue(CommentsSourceProperty, value); }
        }

    
        #region INotifyPropertyChanged Implementation

        /*
         * Create an event to fire when a property is changed
         */
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged(string propertyName)
        {
            // Invalid Event
            if (PropertyChanged == null)
                return;

            // Fire the event
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //var shit = ((ModelPresenter)(this.DataContext)).Comments.Items;
            //var crap =((ICommentPresenter) (shit.First()));
        }
    }
}
