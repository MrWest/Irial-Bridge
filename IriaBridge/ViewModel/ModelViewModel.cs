using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.Presenter;
using WPFLocalization;

namespace IriaBridge.ViewModel
{
    public class ModelViewModel: ItemViewModel<Model>
    {
        protected override PresenterBase<Model> CreatePresenterFor(Model item)
        {
            var model = base.CreatePresenterFor(item);
            var images = ((ModelPresenter)model).Images.Items;
            return model;
        }
    }
}
