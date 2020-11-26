using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class NameablePresenter<TNameable>: PresenterBase<TNameable> where TNameable: Nameable
    {
        public String Name { get { return Object.Name;  } }
        public String Description {  get { return Object.Description;  } }
    }
}
