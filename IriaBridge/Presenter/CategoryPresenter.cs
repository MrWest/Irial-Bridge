using IriaBridge.Business;
using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class CategoryPresenter: NameablePresenter<Category, CategoryApplication>
    {
        public int Section { get { return Object.id_section;  } }
    }
}
