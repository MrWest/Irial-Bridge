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
    public class ModelCommentsViewModel: CommentViewModel
    {
        public int Model { get; set; }

        protected override CommentApplication ApplicationService
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
