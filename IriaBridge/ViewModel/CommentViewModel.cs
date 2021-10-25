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
    public abstract class CommentViewModel<T>: ViewModelBase<Comment,  CommentPresenter<T>, CommentApplication<T>, CommentRepository<T>>
        where T: Item
    {
        public T Owner { get; set; }

        protected override CommentApplication<T> ApplicationService
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
