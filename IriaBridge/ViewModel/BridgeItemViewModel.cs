using IriaBridge.Business;
using IriaBridge.DataAccess;
using IriaBridge.Domain;
using IriaBridge.Presenter;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IriaBridge.ViewModel
{
    public class BridgeItemViewModel: ViewModelBase<BridgeItem, BridgeItemPresenter, BridgeItemApplication, BridgeItemRepository>
    {
        private ICommand _importCommand = new RelayCommand<BridgeItemViewModel>(ExecuteImport, CanExecuteImport);
        private static bool CanExecuteImport(BridgeItemViewModel vm)
        {
            return true;
        }

        public void Import(string file)
        {
            ApplicationService.Import(file);
            Reload();
        }

        private static void ExecuteImport(BridgeItemViewModel vm)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileOk += OpenFileDialog_FileOk;
            openFileDialog.Title = "Import Irial Bridge Item";
            openFileDialog.Filter = "ibr files (*.ibr)|*.ibr|All files (*.*)|*.*";
            openFileDialog.DefaultExt = "ibr";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Tag = vm;
            openFileDialog.ShowDialog();
            
        }

        private static void OpenFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string file = ((OpenFileDialog)sender).FileName;
            ((BridgeItemViewModel)((OpenFileDialog)sender).Tag).Import(file);
        }

        public ICommand ImportCommand => _importCommand;
    }
}
