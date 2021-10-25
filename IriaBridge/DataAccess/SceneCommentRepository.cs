using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class SceneCommentRepository: CommentRepository<Scene>
    {
        protected override String Path { get { return "scenes/get_scene_comments.php"; } }
    }
}
