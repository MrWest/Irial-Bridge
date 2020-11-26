using IriaBridge.Domain;
using IriaBridge.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.ViewModel
{
    public class ItemViewModel<TItem> : NameableViewModel<TItem> where TItem : Item
    {
    }
}
