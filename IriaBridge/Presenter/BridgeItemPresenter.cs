using IriaBridge.Business;
using IriaBridge.Domain;
using IriaBridge.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;
using IriaBridge.SystemSettings;
using CommonServiceLocator;

namespace IriaBridge.Presenter
{
    public class BridgeItemPresenter: NameablePresenter<BridgeItem, BridgeItemApplication>, IBridgeItemPresenter
    {
        private ICommand _exportCommand = new RelayCommand<IBridgeItemPresenter>(ExecuteExport, CanExecuteExport);
        private ICommand _changePreviewCommand = new RelayCommand<IBridgeItemPresenter>(ExecuteChangePreview, CanExecuteChangePreview);
        private ICommand _installCommand = new RelayCommand<IBridgeItemPresenter>(ExecuteInstall, CanExecuteInstall);
        private ICommand _uninstallCommand = new RelayCommand<IBridgeItemPresenter>(ExecuteUninstall, CanExecuteUninstall);

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

        public bool IsInstalled { get { return Directory.Exists(Object.InstallDirectory); } }

        private static bool CanExecuteExport(IBridgeItemPresenter item)
        {
            var settings = ServiceLocator.Current.GetInstance(typeof(BridgeSettingsPresenter)) as BridgeSettingsPresenter;
            return item != null && !string.IsNullOrEmpty(item.Name) && !string.IsNullOrEmpty(item.Description) 
                && !string.IsNullOrEmpty(item.PreviewImage) && Directory.Exists(settings.ExportDirectory);
        }

        public void Export()
        {
            ApplicationService.Export(Object);
        }

        private static void ExecuteExport(IBridgeItemPresenter item)
        {
            item.Export();
        }

        public ICommand ExportCommand => _exportCommand;


        private static bool CanExecuteChangePreview(IBridgeItemPresenter item)
        {
            return true;
        }

        public void ChangePreview(string newImagePath)
        {
            ApplicationService.ChangePreview(newImagePath, Object);
            PreviewImage = newImagePath;
        }
        private static void ExecuteChangePreview(IBridgeItemPresenter item)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileOk += OpenFileDialog_FileOk;
            openFileDialog.Title = "Change Bridge Item PreviewImage";
            openFileDialog.Filter = "Files|*.jpg;*.jpeg;*.png";
            openFileDialog.DefaultExt = "png";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Tag = item;
            openFileDialog.ShowDialog();
        }

        private static void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {

            string file = ((OpenFileDialog)sender).FileName;
            var item = (IBridgeItemPresenter)((OpenFileDialog)sender).Tag;
            item.ChangePreview(file);
        }

        public ICommand ChangePreviewCommand => _changePreviewCommand;


        public void Install()
        {
            ApplicationService.Install(Object);
            OnPropertyChanged("IsInstalled");
        }
        private static void ExecuteInstall(IBridgeItemPresenter item)
        {
            item.Install();
        }

        private static bool CanExecuteInstall(IBridgeItemPresenter item)
        {
            return item != null  && !item.IsInstalled;
        }

        public ICommand InstallCommand => _installCommand;

        public void Uninstall()
        {
            ApplicationService.Uninstall(Object);
            OnPropertyChanged("IsInstalled");
        }
        private static void ExecuteUninstall(IBridgeItemPresenter item)
        {
            item.Uninstall();
        }

        private static bool CanExecuteUninstall(IBridgeItemPresenter item)
        {
            return item != null && item.IsInstalled;
        }

        public ICommand UninstallCommand => _uninstallCommand;

    }
}
