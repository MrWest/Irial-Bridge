using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FirstFloor.ModernUI.Presentation
{
    /// <summary>
    /// Represents an observable collection of controls.
    /// </summary>
    public class ControlCollection : ObservableCollection<Control>
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="ControlCollection"/> class.
        /// </summary>
        public ControlCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlCollection"/> class that contains specified controls.
        /// </summary>
        /// <param name="controls">The links that are copied to this collection.</param>
        public ControlCollection(IEnumerable<Control> controls)
        {
            if (controls == null) {
                throw new ArgumentNullException("controls");
            }
            foreach (var control in controls) {
                Add(control);
            }
        }
    }
}
