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
        protected override String Path { get { return "models/get_model_comments.php"; } }
        protected override string Parameters { get => base.Parameters+"&idModel=" + Model;  }
        public int Model => Owner;
    }
}
