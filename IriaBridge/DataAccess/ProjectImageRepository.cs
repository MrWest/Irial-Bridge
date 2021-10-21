using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class ProjectImageRepository: ImageRepository
    {
        protected override String Path { get { return "models/get_model_images.php"; } }
        protected override string Parameters { get => base.Parameters+"&idModel=" + Project;  }
        public int Project => Owner;
    }
}
