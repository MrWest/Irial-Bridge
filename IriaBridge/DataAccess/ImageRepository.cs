using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class ImageRepository: Repository<Image>
    {
        public int Owner { get; set; }
    }
}
