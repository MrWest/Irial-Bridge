using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity.ServiceLocation;
using Unity;
using CommonServiceLocator;
using IriaBridge.DataAccess;
using IriaBridge.Domain;
using IriaBridge.Presenter;
using IriaBridge.ViewModel;
using IriaBridge.Business;
using Infralution.Localization.Wpf;
using System.Globalization;
using IriaBridge.Views;
using System.IO;

namespace IriaBridge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            //Init UnityContainer
            //model
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<Repository<Model>, ModelRepository>();
            unityContainer.RegisterType<PresenterBase<Model>, ModelPresenter>();
            unityContainer.RegisterType<ApplicationBase<Model, ModelRepository>, ModelApplication>();
            unityContainer.RegisterType<Repository<Model>, ModelRepository>();
            // images
            unityContainer.RegisterType<PresenterBase<Image>, ImagePresenter>();
            unityContainer.RegisterType<Repository<Image>, ModelImageRepository>();
            unityContainer.RegisterType<ImageRepository, ModelImageRepository>();
            unityContainer.RegisterType<ApplicationBase<Image, ImageRepository>, ImagesApplication>();

            //category
            unityContainer.RegisterType<CategoryPresenter, CategoryPresenter>();
            unityContainer.RegisterType<CategoryRepository, CategoryRepository>();
            unityContainer.RegisterType<CategoryApplication, CategoryApplication>();

             //section
            unityContainer.RegisterType<SectionPresenter, SectionPresenter>();
            unityContainer.RegisterType<SectionRepository, SectionRepository>();
            unityContainer.RegisterType<SectionApplication, SectionApplication>();

            var unityServiceLocator = new UnityServiceLocator(unityContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            var cartViewModel = new CartViewModel();
            unityContainer.RegisterInstance(cartViewModel);

            var categoryViewModel = new CategoryViewModel();
            unityContainer.RegisterInstance(categoryViewModel);

            var sectionViewModel = new SectionViewModel();
            unityContainer.RegisterInstance(sectionViewModel);


           
            CultureManager.UICulture = new CultureInfo(CultureInfo.CurrentCulture.Name);

            //var check = ServiceLocator.Current.GetInstance(typeof(CartViewModel));

        }
    }
}
