using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class ModelCommentRepository: ImageRepository
    {
        protected override String Path { get { return "projects/get_project_comments.php"; } }
        protected override string Parameters { get => base.Parameters+ "&idProject=" + Project;  }
        public int Project => Owner;
    }
}
