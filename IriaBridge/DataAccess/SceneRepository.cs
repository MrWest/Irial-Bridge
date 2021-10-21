using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.Domain;

namespace IriaBridge.DataAccess
{
    public class SceneRepository : Repository<Scene>
    {
        protected override String Path { get { return "scenes/get_scenes.php";  } }
    }
}
