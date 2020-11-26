using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Domain
{
    class User:  Entity
    {
        String FirstName { get; set; }
        String LastName { get; set; }
        Image Picture { get; set; }

        int  Models { get; set; }
    }
}
