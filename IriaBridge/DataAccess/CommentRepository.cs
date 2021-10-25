using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public abstract class CommentRepository<T>: Repository<Comment>
        where T: Item
    {
        public T Owner { get; set; }
        protected override string Parameters { get => base.Parameters + "id=" + Owner.Id; }
    }
}
