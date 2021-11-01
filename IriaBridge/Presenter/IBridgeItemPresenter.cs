using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public interface IBridgeItemPresenter: INameablePresenter
    {
        String Type { get; }
        String Status { get; }
        String Date { get; }
        String PreviewImage { get; }
        void Export();
    }
}
