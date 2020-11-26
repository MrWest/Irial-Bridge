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
    public class ModelImagesViewModel: ImagesViewModel
    {
        public int Model { get; set; }

        protected override ImagesApplication ApplicationService
        {
            get
            {
                var _app = base.ApplicationService;
                _app.Owner = Model;
                return _app;
            }
        }
    }
}
