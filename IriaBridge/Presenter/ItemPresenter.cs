using CommonServiceLocator;
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
    public class ItemPresenter<TItem>: NameablePresenter<TItem>, IItemPresenter where TItem: Item
    {

        public decimal Price { get { return Object.Price; } }
        public String Version { get { return Object.Version; } }

        ModelImagesViewModel _modelImagesViewModel = ServiceLocator.Current.GetInstance<ModelImagesViewModel>();

        ModelCommentsViewModel _modelCommentsViewModel = ServiceLocator.Current.GetInstance<ModelCommentsViewModel>();


        private ICommand _addToCartCommand = new RelayCommand<IItemPresenter>(ExecuteAddItem, CanExecuteAddItem);

        private static bool CanExecuteAddItem(IItemPresenter obj)
        {
            if (obj == null) return false;

            var cartViewModel = ServiceLocator.Current.GetInstance(typeof(CartViewModel)) as CartViewModel;

            if (cartViewModel.Items.Count == 0) return true;

            var result = cartViewModel.Items.FirstOrDefault(item => item.ItemId == obj.ItemId);

            return result == null;
        }

        private static void ExecuteAddItem(IItemPresenter obj)
        {
            var cartViewModel = ServiceLocator.Current.GetInstance(typeof(CartViewModel)) as CartViewModel;
            cartViewModel.AddItem(obj);
        }

        public ICollection<ImagePresenter> Images {
            get {
               
                return Object.Images.Select(i => new ImagePresenter() { Object= i}).ToArray();
            } }

        public ImagePresenter  Image => Images.First();

        public ICollection<CommentPresenter> Comments
        {
            get
            {

                return Object.Comments.Select(i => new CommentPresenter() { Object = i }).ToArray();
            }
        }

        public ICommand AddToCart => _addToCartCommand;

        public int ItemId => Object.Id;

        public String CategoryName => Object.category_name;
    }
}
