using FirstFloor.ModernUI;
using FirstFloor.ModernUI.Windows;
using IriaBridge.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IriaBridge.Views.Utils
{
    class ContentLoader : IContentLoader
    {
        private IViewModelBase _viewModel;
        public ContentLoader()
        {
           
        }

        // This event handler is where the time-consuming work is done.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _viewModel.LazyLoad();
        }

        private void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _viewModel.Load();
            if (OnCompleted != null)
            {
                OnCompleted.Invoke();
                _viewModel.Notify();
            }
        }

         public Task<object> LoadContentAsync(Uri uri, System.Threading.CancellationToken cancellationToken)
        {
           
            //BackgroundWorker bw = new BackgroundWorker();
            //bw.DoWork += backgroundWorker1_DoWork;
            //bw.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
            //bw.RunWorkerAsync();

            if (!Application.Current.Dispatcher.CheckAccess())
            {
                throw new InvalidOperationException(Resources.UIThreadRequired);
            }

            // scheduler ensures LoadContent is executed on the current UI thread
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();

            return Task.Factory.StartNew(() => LoadContent(uri), cancellationToken, TaskCreationOptions.None, scheduler);
        }


        /// <summary>
        /// Loads the content from specified uri.
        /// </summary>
        /// <param name="uri">The content uri</param>
        /// <returns>The loaded content.</returns>
        protected virtual object LoadContent(Uri uri)
        {
            // don't do anything in design mode
            if (ModernUIHelper.IsInDesignMode)
            {
                return null;
            }
            var view = Application.LoadComponent(uri) as UserControl;
            var datacontext = view.DataContext as IViewModelBase;
            if(datacontext != null)
            {
                _viewModel = datacontext;
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += backgroundWorker1_DoWork;
                bw.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
                bw.RunWorkerAsync();
            }
            return view;
        }

        /// <summary>
        /// Asynchronously loads content from specified uri.
        /// </summary>
        /// <returns>The loaded content.</returns>
        public Action OnCompleted { get; set; }
    }
}
