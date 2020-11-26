using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Domain
{
    public class Nameable: Entity
    {
        public String Name { get; set; }
        public String Description { get => _description; set { _description = value; } }

        String _description;
        public String general_description { get => _description; set { _description = value; } }

        public String full_description { get; set; }
    }
}
