using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Domain
{
    public class BridgeItem: Nameable
    {
        public String Type { get; set; }
        public String Status { get; set; }
        public String Date { get; set; }
        public String PreviewImage { get; set; }
        public String DataInfoPath { get; set; }
        public String Directory { get; set; }
    }
}
