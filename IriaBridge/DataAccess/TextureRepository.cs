using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.Domain;

namespace IriaBridge.DataAccess
{
    public class TextureRepository : Repository<Texture>
    {
        protected override String Path { get { return "textures/get_textures.php";  } }
    }
}
