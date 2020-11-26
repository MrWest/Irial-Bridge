using IriaBridge.Domain;
using IriaBridge.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.Business;
using IriaBridge.DataAccess;

namespace IriaBridge.ViewModel
{
    public class ImagesViewModel: ViewModelBase<Image,  ImagePresenter, ImagesApplication, ImageRepository>
    {
        public int Owner { get; set; }

        protected override ImagesApplication ApplicationService
        {
            get
            {
                var _app = base.ApplicationService;
                _app.Owner = Owner;
                return _app;
            }
        }
    }
}
