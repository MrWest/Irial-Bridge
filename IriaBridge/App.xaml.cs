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
using System.Globalization;
using IriaBridge.Views;
using System.IO;
using WPFLocalization;

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
            UnityContainer unityContainer = new UnityContainer();
            //model
            unityContainer.RegisterType<Repository<Model>, ModelRepository>();
            unityContainer.RegisterType<PresenterBase<Model>, ModelPresenter>();
            unityContainer.RegisterType<ApplicationBase<Model, ModelRepository>, ModelApplication>();
            //project
            unityContainer.RegisterType<Repository<Project>, ProjectRepository>();
            unityContainer.RegisterType<PresenterBase<Project>, ProjectPresenter>();
            unityContainer.RegisterType<ApplicationBase<Project, ProjectRepository>, ProjectApplication>();
            //textures
            unityContainer.RegisterType<Repository<Texture>, TextureRepository>();
            unityContainer.RegisterType<PresenterBase<Texture>, TexturePresenter>();
            unityContainer.RegisterType<ApplicationBase<Texture, TextureRepository>, TextureApplication>();
            //scenes
            unityContainer.RegisterType<Repository<Scene>, SceneRepository>();
            unityContainer.RegisterType<PresenterBase<Scene>, ScenePresenter>();
            unityContainer.RegisterType<ApplicationBase<Scene, SceneRepository>, SceneApplication>();
            // images
            unityContainer.RegisterType<PresenterBase<Image>, ImagePresenter>();
            unityContainer.RegisterType<Repository<Image>, ModelImageRepository>();
            unityContainer.RegisterType<ImageRepository, ModelImageRepository>();
            unityContainer.RegisterType<ApplicationBase<Image, ImageRepository>, ImagesApplication>();
            // comments
            unityContainer.RegisterType<CommentPresenter<Model>, ModelCommentPresenter>();
            unityContainer.RegisterType<CommentViewModel<Model>, ModelCommentViewModel>();
            unityContainer.RegisterType<CommentRepository<Model>, ModelCommentRepository>();
            unityContainer.RegisterType<CommentApplication<Model>, ModelCommentApplication>();

            unityContainer.RegisterType<CommentPresenter<Project>, ProjectCommentPresenter>();
            unityContainer.RegisterType<CommentViewModel<Project>, ProjectCommentViewModel>();
            unityContainer.RegisterType<CommentRepository<Project>, ProjectCommentRepository>();
            unityContainer.RegisterType<CommentApplication<Project>, ProjectCommentApplication>();

            unityContainer.RegisterType<CommentPresenter<Texture>, TextureCommentPresenter>();
            unityContainer.RegisterType<CommentViewModel<Texture>, TextureCommentViewModel>();
            unityContainer.RegisterType<CommentRepository<Texture>, TextureCommentRepository>();
            unityContainer.RegisterType<CommentApplication<Texture>, TextureCommentApplication>();

            unityContainer.RegisterType<CommentPresenter<Scene>, SceneCommentPresenter>();
            unityContainer.RegisterType<CommentViewModel<Scene>, SceneCommentViewModel>();
            unityContainer.RegisterType<CommentRepository<Scene>, SceneCommentRepository>();
            unityContainer.RegisterType<CommentApplication<Scene>, SceneCommentApplication>();

            
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



            LocalizationManager.UICulture = new CultureInfo(CultureInfo.CurrentCulture.Name);

            //var check = ServiceLocator.Current.GetInstance(typeof(CartViewModel));

        }
    }
}
