using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.Domain;

namespace IriaBridge.DataAccess
{
    public class ProjectRepository: Repository<Project>
    {
        protected override String Path { get { return "projects/get_projects.php";  } }
    }
}
