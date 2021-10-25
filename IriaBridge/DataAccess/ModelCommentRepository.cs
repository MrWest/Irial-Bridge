﻿using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class ModelCommentRepository: CommentRepository<Model>
    {
        protected override String Path { get { return "models/get_model_comments.php"; } }
    }
}
