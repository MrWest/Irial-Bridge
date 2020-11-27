using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.DataAccess;

namespace IriaBridge.Business
{
    public class CommentApplication: ApplicationBase<Comment, CommentRepository>
    {
        public int Owner { get; set; }
        protected override CommentRepository Repository
        {
            get
            {
                var _repo = base.Repository;
                _repo.Owner = Owner;
                return _repo;
            }
        }
    }
}
