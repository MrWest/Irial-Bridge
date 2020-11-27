using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class CommentPresenter: PresenterBase<Comment>
    {
        public String Comment => Object?.Message;
        public String Date => Object?.Date;
        public String UserName => Object?.UserName;
        public String UserPicture => Object?.UserPicture;

    }
}
