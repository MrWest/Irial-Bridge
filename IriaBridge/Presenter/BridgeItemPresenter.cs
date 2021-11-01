using IriaBridge.Business;
using IriaBridge.Domain;
using IriaBridge.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IriaBridge.Presenter
{
    public class BridgeItemPresenter: NameablePresenter<BridgeItem, BridgeItemApplication>, IBridgeItemPresenter
    {
        private ICommand _exportCommand = new RelayCommand<IBridgeItemPresenter>(ExecuteExport, CanExecuteExport);

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

        private static bool CanExecuteExport(IBridgeItemPresenter item)
        {
            return item != null && !string.IsNullOrEmpty(item.Name) && !string.IsNullOrEmpty(item.Description) && !string.IsNullOrEmpty(item.PreviewImage);
        }

        public void Export()
        {
            _application.Export(Object);
        }

        private static void ExecuteExport(IBridgeItemPresenter item)
        {
            item.Export();
        }

        public ICommand ExportCommand => _exportCommand;
    }
}
