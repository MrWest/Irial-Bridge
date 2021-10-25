using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public interface ICommentPresenter
    {
         String Comment { get; }
         String Date { get; }
         String UserName { get; }
         String UserPicture { get; }

    }
}
