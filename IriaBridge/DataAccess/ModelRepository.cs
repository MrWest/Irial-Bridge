using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.Domain;

namespace IriaBridge.DataAccess
{
    public class ModelRepository: Repository<Model>
    {
        protected override String Path { get { return "models/get_models.php";  } }
    }
}
