using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.ViewModel
{
    public interface IViewModelBase
    {
        void Load();
        void LazyLoad();
        void Notify();
        bool IsLoaded { get; }
    }
}
