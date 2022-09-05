using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IriaBridge.Views.Controls
{
    class LinkButton: Button
    {
        private Uri source;
        /// <summary>
        /// Gets or sets the source uri.
        /// </summary>
        /// <value>The source.</value>
        public Uri Source
        {
            get
            {

                return  this.source;
            }
            set
            {
                if (this.source != value)
                {
                    this.source = value;
                }
            }
        }
    }
}
