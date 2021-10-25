using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class ProjectCommentRepository: CommentRepository<Project>
    {
        protected override String Path { get { return "projects/get_project_comments.php"; } }
    }
}
