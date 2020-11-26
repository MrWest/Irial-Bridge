using CommonServiceLocator;
using IriaBridge.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Views.Utils
{
    public class ViewModelLocator
    {
        public ModelViewModel ModelViewModel { get
            {
                var models = ServiceLocator.Current.GetInstance(typeof(ModelViewModel)) as ModelViewModel;
                if (!models.IsLoaded) models.Load();
                return models;
            } }
    }
}
