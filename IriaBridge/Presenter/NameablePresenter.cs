using IriaBridge.Business;
using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class NameablePresenter<TNameable, TApplication>: PresenterBase<TNameable, TApplication> 
        where TNameable: Nameable
        where TApplication: IApplicationBase<TNameable>
    {
        public String Name { get { return Object.Name; }
            set { SetProperty(v => Object.Name = v, value); }
        }
        public String Description {  get { return Object.Description; }
            set { SetProperty(v => Object.Description = v, value); }
        }
    }
}
