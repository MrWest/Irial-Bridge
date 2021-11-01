using CommonServiceLocator;
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
    public class ItemPresenter<TItem, TApplication>: NameablePresenter<TItem, TApplication>, IItemPresenter
        where TItem: Item
         where TApplication : IApplicationBase<TItem>
    {

        public decimal Price { get { return Object.Price; } }
        public String Version { get { return Object.Version; } }

        CommentViewModel<TItem> _itemCommentsViewModel = ServiceLocator.Current.GetInstance<CommentViewModel<TItem>>();


        private ICommand _addToCartCommand = new RelayCommand<IItemPresenter>(ExecuteAddItem, CanExecuteAddItem);

        private static bool CanExecuteAddItem(IItemPresenter obj)
        {
            if (obj == null) return false;

            var cartViewModel = ServiceLocator.Current.GetInstance(typeof(CartViewModel)) as CartViewModel;

            if (cartViewModel.Items.Count == 0) return true;

            var result = cartViewModel.Items.FirstOrDefault(item => item.Id == obj.Id);

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

        public CommentViewModel<TItem> Comments
        {
            get
            {
                if (!_itemCommentsViewModel.IsLoaded)
                {
                    _itemCommentsViewModel.Owner = Object;
                    _itemCommentsViewModel.Load();
                }
                return _itemCommentsViewModel;
            }
        }

        public ICommand AddToCart => _addToCartCommand;

        public int ItemId => Object.Id;

        public String CategoryName => Object.category_name;
    }
}
