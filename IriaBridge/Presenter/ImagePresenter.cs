using IriaBridge.Business;
using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class ImagePresenter: PresenterBase<Image, ImagesApplication>
    {
        public String Url => Object?.Url;
        public String Alt => Object.Alt;

    }
}
