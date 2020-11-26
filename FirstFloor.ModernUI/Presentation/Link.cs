using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FirstFloor.ModernUI.Presentation
{
    /// <summary>
    /// Represents a displayable link.
    /// </summary>
    public class Link
        : Displayable
    {
        private Uri source;
       

        /// <summary>
        /// Dependency property for the text of the Add button of instances.
        /// </summary>
        public static readonly DependencyProperty IsEnableProperty = DependencyProperty.Register("IsEnable", typeof(bool), typeof(Link), new PropertyMetadata(true));


        /// <summary>
        /// Gets or sets the text for the Add button.
        /// </summary>
        public bool IsEnable
        {
            get { return (bool)GetValue(IsEnableProperty); }
            set
            {
                //if (value != null)
                SetValue(IsEnableProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the source uri.
        /// </summary>
        /// <value>The source.</value>
        public Uri Source
        {
            get {

                return IsEnable 
                    || DisplayName.Equals("dark") || DisplayName.Equals("light")
                    || DisplayName.Equals("love") || DisplayName.Equals("hello kitty") || DisplayName.Equals("snowflakes") 
                    || DisplayName.Equals("Introduccion") || DisplayName.Equals("Regulares") || DisplayName.Equals("Configuracion") || DisplayName.Equals("Ayuda") ? this.source:null;
            }
            set
            {
                if (this.source != value) {
                    this.source = value;
                    OnPropertyChanged("Source");
                }
            }
        }

        ///// <summary>
        ///// Gets or sets the display name.
        ///// </summary>
        ///// <value>The display name.</value>
        //public string DisplayName2
        //{
        //    get
        //    {
        //        if (Command == null)
        //            return "shit!";
        //        return Command.ToString();
        //    }
        //    set
        //    {
        //       // Command = value;
        //            OnPropertyChanged("DisplayName2");
               
        //    }
        //}

        ///// <summary>
        /////      Dependency property containing the command that allows to execute selected planned items in instance of
        /////   
        ///// </summary>
        //public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(object), typeof(Link), new PropertyMetadata(DefaultValue));

        //private static void DefaultValue(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        //{
        //    var shit = dependencyPropertyChangedEventArgs.NewValue; //.throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Gets or sets the command that allows to add a child investment element to the one currently focused.
        ///// </summary>
        //public object Command
        //{
        //    get { return (object)GetValue(CommandProperty); }
        //    set
        //    {
        //        SetValue(CommandProperty, value);
        //        OnPropertyChanged("Command");
        //    }
        //}
    }
}
