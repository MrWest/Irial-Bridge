using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.DataAccess;

namespace IriaBridge.Business
{
    public abstract class CommentApplication<T>: ApplicationBase<Comment, CommentRepository<T>>
        where T: Item
    {
        public T Owner { get; set; }
        protected override CommentRepository<T> Repository
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
