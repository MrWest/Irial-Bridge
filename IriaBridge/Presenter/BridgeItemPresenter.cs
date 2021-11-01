using IriaBridge.Business;
using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class BridgeItemPresenter: NameablePresenter<BridgeItem, BridgeItemApplication>, IBridgeItemPresenter
    {
        public String Type { get { return Object.Type; }
            set { SetProperty(v => Object.Type = v, value); }
        }
        public String Status { get { return Object.Status; }
            set { SetProperty(v => Object.Status = v, value); }
        }
        public String Date { get { return Object.Date; }
            set { SetProperty(v => Object.Date = v, value); }
        }
        public String PreviewImage { get { return Object.PreviewImage; }
            set { SetProperty(v => Object.PreviewImage = v, value); }
        }
    }
}
