using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class TextureCommentRepository: CommentRepository<Texture>
    {
        protected override String Path { get { return "textures/get_texture_comments.php"; } }
    }
}
