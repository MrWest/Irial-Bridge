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
    public class ApplicationBase<T, TRepository> 
        where T: Entity
        where TRepository: Repository<T>
    {
        TRepository _repository = ServiceLocator.Current.GetInstance<TRepository>();
        protected virtual TRepository Repository { get { return _repository;  } }
        public ICollection<T> Entities => Repository.Entities;
    }
}
