using IriaBridge.Business;
using IriaBridge.DataAccess;
using IriaBridge.Domain;
using IriaBridge.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.ViewModel
{
    class CategoryViewModel: ViewModelBase<Category, CategoryPresenter, CategoryApplication, CategoryRepository>
    {
    }
}
