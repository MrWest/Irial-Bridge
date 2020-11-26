using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class SectionRepository: Repository<Section>
    {
        protected override String Path => "sections/get_sections.php";
    }
}
