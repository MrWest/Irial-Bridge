using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Business
{
    public interface IApplicationBase<T>
        where T : Entity
    {
        T UpdateEntity(T entity);
        bool CanUpdate(T entity);
    }
}
