
using IriaBridge.Business;
using IriaBridge.Domain;
using IriaBridge.Presenter;
using Microsoft.Win32;

namespace IriaBridge.SystemSettings

{
    public class BridgeSettingsPresenter : PresenterBase<BridgeSettings, BridgeSettingsApplication>
    {
        public BridgeSettingsPresenter()
        {
            Object = ApplicationService.BridgeSettings;
        }
        
        public string LocalRepository { get { return Object.LocalRepository; } set { SetProperty(v => Object.LocalRepository = v, value); } }
        public string ExportDirectory { get { return Object.ExportDirectory; } set { SetProperty(v => Object.ExportDirectory = v, value); } }
        public string[] LumionVersions { get { return Object.LumionVersions; } set { SetProperty(v => Object.LumionVersions = v, value); } }
        public string TargetedVersion { get { return Object.TargetedVersion; } set { SetProperty(v => Object.TargetedVersion = v, value); } }

    }
}
