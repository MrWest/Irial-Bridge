using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Presenter
{
    public class PresenterBase<T>: INotifyPropertyChanged 
        where T: Entity
    {
        public T Object { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
