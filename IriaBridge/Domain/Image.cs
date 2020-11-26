using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Domain
{
    public class Image: Entity
    {
        public String Url { get; set; }
        public String Alt { get; set; }

        int Owner { get; set; }
    }
}
