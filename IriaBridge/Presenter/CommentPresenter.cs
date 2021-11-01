using IriaBridge.Business;
using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class CommentPresenter<T>: PresenterBase<Comment, CommentApplication<T>>, ICommentPresenter
        where T:  Item
    {
        T Owner { get; set; }
        public String Comment => Object?.Message;
        public String Date => Object?.Date;
        public String UserName => Object?.UserName;
        public String UserPicture => Object?.UserPicture;

    }
}
