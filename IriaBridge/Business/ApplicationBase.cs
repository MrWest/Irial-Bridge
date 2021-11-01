using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.Domain;
using CommonServiceLocator;
using IriaBridge.DataAccess;

namespace IriaBridge.Business
{
    public class ApplicationBase<T, TRepository>: IApplicationBase<T>
        where T: Entity
        where TRepository: Repository<T>
    {
        TRepository _repository = ServiceLocator.Current.GetInstance<TRepository>();
        protected virtual TRepository Repository { get { return _repository;  } }
        public ICollection<T> Entities => Repository.Entities;

        public T UpdateEntity(T entity)
        {
            return Repository.UpdateEntity(entity);
        }

        public virtual bool CanUpdate(T entity)
        {
            return true;
        }
    }
}
